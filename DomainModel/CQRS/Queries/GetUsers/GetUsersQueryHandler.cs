using System;
using CQRS.Queries;
using DomainModel.Services.User;
using System.Collections.Generic;
using DomainModel.Classes.User;

namespace DomainModel.CQRS.Queries.GetUsers
{
    public class GetUsersQueryHandler: IQueryHandler<GetUsersQuery,GetUsersQueryResult>
    {
        private readonly IGetUsers getUsers;

        public GetUsersQueryHandler(IGetUsers getUser)
        {
            this.getUsers = getUser ?? throw new ArgumentNullException(nameof(getUser));
        }

        public GetUsersQueryResult Handle(GetUsersQuery query)
        {
            var users = this.getUsers.GetQuery();
            return new GetUsersQueryResult(users);
        }
    }
}

