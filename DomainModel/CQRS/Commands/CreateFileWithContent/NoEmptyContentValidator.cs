using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Commands.Validators;
using CQRS.Validation;

namespace DomainModel.CQRS.Commands.CreateFileWithContent
{
    public class NoEmptyContentValidator : ICommandValidator<CreateFileWithContentCommand>
    {
        public IEnumerable<ValidationResult> Validate(CreateFileWithContentCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Content))
                yield return new ValidationResult("Il content non può essere vuoto");
        }
    }
}
