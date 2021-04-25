using System;
using System.Collections.Generic;

namespace DomainModel.CQRS.Queries.GetUsers
{
    public class GetUsersQueryResult
    {
        public GetUsersQueryResult(IEnumerable<string> users)
        {
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public IEnumerable<string> Users { get; }
    }
}