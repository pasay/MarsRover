using FluentValidation;
using MarsRover.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.ConsoleApp.Validations
{
    public class MoveListInputValidator : AbstractValidator<string>
    {
        public List<string> MoveTypeEnumList => Enum.GetNames(typeof(MoveType)).ToList();

        public MoveListInputValidator()
        {
            RuleFor(x => x).NotNull().WithMessage(ConsoleApp.Properties.Resources.NullOrEmpty).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEmpty().WithMessage(ConsoleApp.Properties.Resources.NullOrEmpty).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEqual(Constants.START).WithMessage(string.Format(ConsoleApp.Properties.Resources.StartCommandIsNotUse, Constants.START)).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEqual(Constants.EXIT).WithMessage(ConsoleApp.Properties.Resources.ExitSignalDetected).WithErrorCode(Constants.EXIT)
                            .Must(CustomValidator).WithMessage(ConsoleApp.Properties.Resources.MoveListInputValueError).WithErrorCode(Models.Constants.ErrorCodes.RETRY);
        }

        private bool CustomValidator(string arg)
        {
            var values = arg.ToCharArray().ToList();
            if (values.Count == 0)
            {
                return false;
            }

            return values.All(p => MoveTypeEnumList.Contains(p.ToString().ToUpperInvariant()));
        }
    }
}
