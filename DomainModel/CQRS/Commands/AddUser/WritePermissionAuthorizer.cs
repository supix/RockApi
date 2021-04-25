using CQRS.Authorization;
using CQRS.Commands.Authorizers;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AddUser
{
    public class WritePermissionAuthorizer : ICommandAuthorizer<AddUserCommand>
    {
        private readonly ILoggedUserHasWritePermissions loggedUserHasWritePermissions;

        public WritePermissionAuthorizer(ILoggedUserHasWritePermissions loggedUserHasWritePermissions)
        {
            this.loggedUserHasWritePermissions = loggedUserHasWritePermissions ?? throw new ArgumentNullException(nameof(loggedUserHasWritePermissions));
        }

        public IEnumerable<AuthorizationResult> Authorize(AddUserCommand command)
        {
            if (!this.loggedUserHasWritePermissions.CanWrite())
                yield return new AuthorizationResult("User does not have write permissions");
        }
    }
}