using CQRS.Commands;
using DomainModel.CQRS.Queries.GetUsers;
using DomainModel.Services.User;
using DomainModel.Classes.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.User.AddUser
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IAddUser addUser;

        //public UserCommandHandler(IUserSaver userSaver) { this.userSaver = userSaver; }

        public AddUserCommandHandler(IAddUser addUser)
        {
            this.addUser = addUser ?? throw new ArgumentNullException(nameof(addUser));
        }

        public void Handle(AddUserCommand command)
        {
           var user = new Users();

            user.Username = command.Username;
            user.Password = command.Password;
            user.Id = command.Id;
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Active = true;

            this.addUser.Save(user);

        }
    }
}
