using DomainModel.CQRS.Commands.User.AddUser;
using DomainModel.CQRS.Queries.AuthUsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services.User
{
    public interface IAuthenticateUser
    {
        // AddUserCommand Authenticate(string username, string password);
      IEnumerable<AuthUsersQuery> Authenticate(string username, string password);
    }
}
