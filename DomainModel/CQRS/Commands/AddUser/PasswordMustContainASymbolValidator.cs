using CQRS.Commands.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.CQRS.Commands.AddUser
{
    public class PasswordMustContainASymbolValidator : ICommandValidator<AddUserCommand>
    {
        public IEnumerable<ValidationResult> Validate(AddUserCommand command)
        {
            if (command.Password.All(c => char.IsLetterOrDigit(c)))
                yield return new ValidationResult("Password must contain a symbol.");
        }
    }
}