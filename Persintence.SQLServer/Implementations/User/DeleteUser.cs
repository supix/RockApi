using System;
using Persistence.SQLServer.data;
using DomainModel.Classes.User;
using DomainModel.Services.User;
using Microsoft.EntityFrameworkCore;
using DomainModel.CQRS.Queries.GetUsers;
using Serilog;

namespace Persistence.SQLServer.Implementations.User
{
    internal class DeleteUser: IDeleteUser
    {
        private readonly CIRDbContext dbContext;

        public DeleteUser(CIRDbContext CIRdbContext)
        {
            this.dbContext = CIRdbContext;
        }

        public void Delete(Users userCommand)
        {
            try
            {
                var userToDelete = dbContext.Users.FirstOrDefault(usr => usr.Username == userCommand.Username);
                if (userToDelete != null)
                {
                    dbContext.Users.Remove(userToDelete);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                Log.Debug("Errore Insert : {@classe} {@message}", this.ToString(), Ex.Message);
                throw new NotImplementedException("Errore Durante la Delete", Ex);
            }
        }
    }
}

