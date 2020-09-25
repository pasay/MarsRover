using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MarsRover.Models.Enums;

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
                return false;

            return values.All(p => MoveTypeEnumList.Contains(p.ToString().ToUpperInvariant()));
        }
    }
}
