using CQRS.Queries;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetUsers
{
    public class GetUsersQuerydHandler : IQueryHandler<GetUsersQuery, GetUsersQueryResult>
    {
        private readonly IGetUsers getUsers;

        public GetUsersQuerydHandler(IGetUsers getUsers)
        {
            this.getUsers = getUsers ?? throw new ArgumentNullException(nameof(getUsers));
        }

        public GetUsersQueryResult Handle(GetUsersQuery query)
        {
            var users = this.getUsers.Get();
            return new GetUsersQueryResult(users);
        }
    }
}