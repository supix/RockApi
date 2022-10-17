using System;
using DomainModel.Classes.User;
using DomainModel.CQRS.Queries.GetUsers;

namespace DomainModel.Services.User
{
    public interface IDeleteUser
    {
        void Delete(Users userCommand);
    }
}

