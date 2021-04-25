using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface ILoggedUserHasWritePermissions
    {
        bool CanWrite();
    }
}