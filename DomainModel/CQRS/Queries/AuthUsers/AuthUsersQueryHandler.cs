using System;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetUsers;
using DomainModel.Services;
using DomainModel.Services.User;

namespace DomainModel.CQRS.Queries.AuthUsers
{
    public class  AuthUsersQueryHandler : IQueryHandler<AuthUsersQuery, AuthUsersQueryResult>
    {
        private readonly IAuthenticateUser authenticateUser;

        public AuthUsersQueryHandler(IAuthenticateUser authenticateUser)
        {
            this.authenticateUser = authenticateUser ?? throw new ArgumentNullException(nameof(authenticateUser));
        }

        public AuthUsersQueryResult Handle(AuthUsersQuery query)
        {
            var users = this.authenticateUser.Authenticate(query.Username, query.Password);

            return new AuthUsersQueryResult(users);
        }
    }
}

