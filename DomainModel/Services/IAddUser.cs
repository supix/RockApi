using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IAddUser
    {
        void Add(User user);
    }
}