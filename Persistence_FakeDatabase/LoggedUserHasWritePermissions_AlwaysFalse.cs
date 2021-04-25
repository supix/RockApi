using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence_FakeDatabase
{
    internal class LoggedUserHasWritePermissions_AlwaysFalse : ILoggedUserHasWritePermissions
    {
        public bool CanWrite()
        {
            return false;
        }
    }
}