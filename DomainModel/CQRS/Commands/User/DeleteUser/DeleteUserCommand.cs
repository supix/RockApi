using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomainModel.CQRS.Commands.User.DeleteUser
{
    public class DeleteUserCommand
    {
        //public int Id { get; set; }
        public string Username { get; set; }
    }
}
