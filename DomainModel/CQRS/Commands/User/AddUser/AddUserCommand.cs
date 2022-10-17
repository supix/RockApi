using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomainModel.CQRS.Commands.User.AddUser
{
    public class AddUserCommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
