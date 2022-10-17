using CQRS.Commands;
using DomainModel.Services.User;
using DomainModel.Classes.User;
using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.CQRS.Queries.GetUsers;

namespace DomainModel.CQRS.Commands.User.DeleteUser
{
    public class DeleteUserCommandHandler: ICommandHandler<DeleteUserCommand>
    {
        private readonly IDeleteUser deleteUser;

        public DeleteUserCommandHandler(IDeleteUser deleteUser)
        {
            this.deleteUser = deleteUser ?? throw new ArgumentNullException(nameof(deleteUser));
        }

        public void Handle(DeleteUserCommand command)
        {
            var user = new Users();
            user.Username = command.Username;
            this.deleteUser.Delete(user);
        }
    }
}

