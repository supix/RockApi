using System;
using System.Data;
using DomainModel.CQRS.Commands.User.AddUser;
using DomainModel.CQRS.Queries.GetUsers;
using DomainModel.Services.User;
using Microsoft.EntityFrameworkCore;
using Persistence.SQLServer.data;
using DomainModel.Classes.User;
using Serilog;

namespace Persistence.SQLServer.Implementations.User
{
    internal class GetUsers : IGetUsers
    {
        private readonly CIRDbContext dbContext;

        public GetUsers(CIRDbContext CIRdbContext)
        {
            this.dbContext = CIRdbContext;
        }

        public IEnumerable<Users> Get()
        {
            IEnumerable<Users> getUsers = dbContext.Users.AsNoTracking().ToList();

            return getUsers;
        }

        public IEnumerable<GetUsersQuery> GetQuery()
        {

            return (IEnumerable<GetUsersQuery>)dbContext.Users.AsNoTracking().ToList();
        }

        public IEnumerable<AddUserCommand>? getbyCredenziali(string username, string password)
        {
           
            var usr = dbContext.Users.AsNoTracking().Single(usr => usr.Username.Trim().ToLower() == username.ToString().ToLower());
            if (!BCrypt.Net.BCrypt.Verify(password, usr.Password))
                return null;
            
            return (IEnumerable<AddUserCommand>)usr;
        }

        public IEnumerable<Users> getbyUsername(string username)
        {

            Users getUsers = new Users();

            try
            {
                getUsers = dbContext.Users.AsNoTracking().ToList().Single(usr => usr.Username == username);
            }
            catch { getUsers = null; }

           yield return getUsers;
        }
    }
}
