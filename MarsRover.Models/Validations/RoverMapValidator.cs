using FluentValidation;
using MarsRover.Models.Commands;
using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Validations
{
    public class RoverMapValidator : AbstractValidator<IRoverModel>
    {
        private readonly IPointModel pointModel;

        public RoverMapValidator(IPointModel pointModel)
        {
            this.pointModel = pointModel;

            RuleFor(x => x).NotNull().NotEmpty();

            RuleFor(x => x.X).GreaterThanOrEqualTo(0)
                            .WithMessage(Properties.Resources.RoverOutsideMapBorderWest)
                            .WithErrorCode(Constants.ErrorCodes.RETRY);

            RuleFor(x => x.Y).GreaterThanOrEqualTo(0)
                            .WithMessage(Properties.Resources.RoverOutsideMapBorderSouth)
                            .WithErrorCode(Constants.ErrorCodes.RETRY);

            RuleFor(x => x.X).LessThanOrEqualTo(pointModel.X)
                            .WithMessage(Properties.Resources.RoverOutsideMapBorderEast)
                            .WithErrorCode(Constants.ErrorCodes.RETRY);

            RuleFor(x => x.Y).LessThanOrEqualTo(pointModel.Y)
                            .WithMessage(Properties.Resources.RoverOutsideMapBorderNorth)
                            .WithErrorCode(Constants.ErrorCodes.RETRY);
        }
    }
}