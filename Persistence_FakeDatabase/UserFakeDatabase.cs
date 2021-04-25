using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CompositionRoot")]

namespace Persistence_FakeDatabase
{
    internal class UserFakeDatabase : IAddUser, IGetUsers
    {
        private readonly IList<User> users = new List<User>();

        public void Add(User user)
        {
            this.users.Add(user);
        }

        public IEnumerable<string> Get()
        {
            return this.users.Select(u => u.Username);
        }
    }
}