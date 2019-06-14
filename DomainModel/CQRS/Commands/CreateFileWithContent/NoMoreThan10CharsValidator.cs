using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Commands.Validators;
using CQRS.Validation;

namespace DomainModel.CQRS.Commands.CreateFileWithContent
{
    public class NoMoreThan10CharsValidator : ICommandValidator<CreateFileWithContentCommand>
    {
        public IEnumerable<ValidationResult> Validate(CreateFileWithContentCommand command)
        {
            if (command.Content.Length > 10)
                yield return new ValidationResult("Troppo lungo");
        }
    }
}
