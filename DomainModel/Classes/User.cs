using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class User
    {
        public User(string username, string password, bool active)
        {
            this.Username = username;
            this.Password = password;
            this.Active = active;
        }

        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public bool Active { get; protected set; }
    }
}