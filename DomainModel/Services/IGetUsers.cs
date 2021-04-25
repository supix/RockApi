using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IGetUsers
    {
        IEnumerable<string> Get();
    }
}