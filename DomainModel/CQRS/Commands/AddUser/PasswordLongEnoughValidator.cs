using CQRS.Commands.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AddUser
{
    public class PasswordLongEnoughValidator : ICommandValidator<AddUserCommand>
    {
        public IEnumerable<ValidationResult> Validate(AddUserCommand command)
        {
            const int minLength = 8;
            if (command.Password.Length < minLength)
                yield return new ValidationResult($"Password is too short. Minimum length is { minLength } characters.");
        }
    }
}