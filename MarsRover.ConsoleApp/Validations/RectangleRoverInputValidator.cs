using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MarsRover.Models.Enums;
using MarsRover.Models;

namespace MarsRover.ConsoleApp.Validations
{
    public class RectangleRoverInputValidator : AbstractValidator<string>
    {
        public List<string> DirectionTypeEnumList => Enum.GetNames(typeof(DirectionType)).ToList();

        public RectangleRoverInputValidator()
        {
            RuleFor(x => x).NotNull().WithMessage(ConsoleApp.Properties.Resources.NullOrEmpty).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEmpty().WithMessage(ConsoleApp.Properties.Resources.NullOrEmpty).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEqual(Constants.START).WithMessage(string.Format(ConsoleApp.Properties.Resources.StartCommandIsNotUse, Constants.START)).WithErrorCode(Models.Constants.ErrorCodes.RETRY)
                            .NotEqual(Constants.EXIT).WithMessage(ConsoleApp.Properties.Resources.ExitSignalDetected).WithErrorCode(Constants.EXIT)
                            .Must(CustomValidator).WithMessage(ConsoleApp.Properties.Resources.RectangleRoverInputValueError).WithErrorCode(Models.Constants.ErrorCodes.RETRY);
        }

        private bool CustomValidator(string arg)
        {
            var values = arg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (values.Count != 3)
                return false;

            return values.Take(2).All(p => int.TryParse(p, out _))
                && values.Take(2).All(p => int.Parse(p) >= 0)
                && DirectionTypeEnumList.Contains(values.Last().ToUpperInvariant());
        }
    }
}
