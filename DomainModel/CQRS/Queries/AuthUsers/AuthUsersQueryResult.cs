using System;
using DomainModel.CQRS.Queries.GetUsers;
using System.Collections.Generic;

namespace DomainModel.CQRS.Queries.AuthUsers
{
    public class AuthUsersQueryResult
    {
        public AuthUsersQueryResult(IEnumerable<AuthUsersQuery> users)
        {
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }
        public IEnumerable<AuthUsersQuery> Users { get; }
    }
}

