using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AddUser
{
    public class AddUserCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}