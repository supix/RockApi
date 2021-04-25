using CQRS.Commands;
using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AddUser
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IAddUser addUser;

        public AddUserCommandHandler(IAddUser addUser)
        {
            this.addUser = addUser ?? throw new ArgumentNullException(nameof(addUser));
        }

        public void Handle(AddUserCommand command)
        {
            var user = new User(command.Username, command.Password, true);
            this.addUser.Add(user);
        }
    }
}