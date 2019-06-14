using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.CreateFileWithContent
{
    public class CreateFileWithContentCommand
    {
        public string Content { get; set; }
    }
}
