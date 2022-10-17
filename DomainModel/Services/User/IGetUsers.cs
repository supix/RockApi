using DomainModel.CQRS.Commands.User.AddUser;
using DomainModel.CQRS.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Classes.User;


namespace DomainModel.Services.User
{
    public interface IGetUsers
    {
        IEnumerable<Users> Get();

        IEnumerable<GetUsersQuery> GetQuery();

        IEnumerable<AddUserCommand> getbyCredenziali(string username, string password);

        IEnumerable<Users> getbyUsername(string username);
       
    }
}
