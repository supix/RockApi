using System;
using DomainModel.Classes.User;
using DomainModel.CQRS.Queries.GetUsers;

namespace DomainModel.Services.User
{
    public interface IAddUser
    {
        void Save(Users user);
    }
}

