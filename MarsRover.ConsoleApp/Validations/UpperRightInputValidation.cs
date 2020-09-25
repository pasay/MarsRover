using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.ConsoleApp.Validations
{
    public class UpperRightInputValidator : AbstractValidator<string>
    {
        public UpperRightInputValidator()
        {
            RuleFor(x => x).NotNull().WithMessage(ConsoleApp.Properties.Resources.NullOrEmpty).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEmpty().WithMessage(ConsoleApp.Properties.Resources.NullOrEmpty).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEqual(Constants.START).WithMessage(string.Format(ConsoleApp.Properties.Resources.StartCommandIsNotUse, Constants.START)).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEqual(Constants.EXIT).WithMessage(ConsoleApp.Properties.Resources.ExitSignalDetected).WithErrorCode(Constants.EXIT)
                            .Must(CustomValidator).WithMessage(ConsoleApp.Properties.Resources.UpperRightInputValueError).WithErrorCode(Models.Constants.ErrorCodes.RETRY);
        }

        private bool CustomValidator(string arg)
        {
            var values = arg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (values.Count != 2)
                return false;

            return values.All(p => int.TryParse(p, out _))
                && values.Take(2).All(p => int.Parse(p) >= 0);
        }
    }
}
