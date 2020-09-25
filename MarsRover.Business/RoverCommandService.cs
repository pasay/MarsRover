using MarsRover.Models.Commands;
using MarsRover.Models.Enums;
using MarsRover.Models.Planet;
using MarsRover.Models.Planet.Imp;
using MarsRover.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Business
{
    public class RoverCommandService : IRoverCommandService
    {
        public RoverCommandService(IRoverCommandModel roverCommandModel)
        {
            RoverCommandModel = roverCommandModel;
        }

        public IRoverCommandModel RoverCommandModel { get; set; }

        public List<IRoverCommandResult> Run()
        {
            List<IRoverCommandResult> result = new List<IRoverCommandResult>();
            List<IRoverCommandResult> resultOutput = new List<IRoverCommandResult>()
            {
                new RoverCommandResult() { VerboseType = Models.Enums.ResultType.Warn, Verbose = $"\r\n\r\n[____________OUTPUT____________]" }
            };
            foreach (var rover in RoverCommandModel.RoverCommand)
            {
                result.Add(new RoverCommandResult() { VerboseType = Models.Enums.ResultType.Success, Verbose = $"Rover([{rover.RoverModel.ToString()}]) started." });
                var roverModel = rover.RoverModel.Clone();
                foreach (var moveItem in rover.MoveListModel)
                {
                    result.Add(Move(rover, moveItem));
                }

                result.Add(new RoverCommandResult() { VerboseType = Models.Enums.ResultType.Success, Verbose = $"Rover([{roverModel.ToString()}]) movement finished. Rover last position: [{rover.RoverModel.ToString()}]" });
                resultOutput.Add(new RoverCommandResult() { VerboseType = Models.Enums.ResultType.Success, Verbose = $"Rover([{roverModel.ToString()}]) -> [{rover.RoverModel.ToString()}]" });
            }

            result.AddRange(resultOutput);
            return result;
        }

        public IRoverCommandResult Move(IRoverCommand rover, MoveType moveItem)
        {
            IRoverCommandResult roverCommandResult = new RoverCommandResult() { VerboseType = ResultType.Success, Verbose = $"The movement of the rover([{rover.RoverModel.ToString()}]) for [{moveItem.ToString()}]." };
            var newRoverModel = rover.RoverModel.Clone();
            switch (moveItem)
            {
                case MoveType.L:
                    newRoverModel.Direction = (DirectionType)(((((int)newRoverModel.Direction) - 1) + 4) % 4);
                    break;
                case MoveType.R:
                    newRoverModel.Direction = (DirectionType)((((int)newRoverModel.Direction) + 1) % 4);
                    break;
                case MoveType.M:
                    switch (newRoverModel.Direction)
                    {
                        case DirectionType.E:
                            newRoverModel.X++;
                            break;
                        case DirectionType.W:
                            newRoverModel.X--;
                            break;
                        case DirectionType.N:
                            newRoverModel.Y++;
                            break;
                        case DirectionType.S:
                            newRoverModel.Y--;
                            break;
                        default:
                            roverCommandResult.VerboseType = ResultType.Error;
                            roverCommandResult.Verbose = (new NotImplementedException()).Message;
                            return roverCommandResult;
                    }
                    break;
                default:
                    roverCommandResult.VerboseType = ResultType.Error;
                    roverCommandResult.Verbose = (new NotImplementedException()).Message;
                    return roverCommandResult;
            }

            RoverMapValidator roverMapValidator = new RoverMapValidator(RoverCommandModel.UpperRight);
            var result = roverMapValidator.Validate(newRoverModel);
            if (result.IsValid)
            {
                rover.RoverModel = newRoverModel;
                roverCommandResult.Verbose += $" -> [{newRoverModel.ToString()}]";
            }
            else
            {
                roverCommandResult.VerboseType = ResultType.Warn;
                roverCommandResult.Verbose = string.Join(" ", result.Errors.Select(p => p.ErrorMessage));
            }

            return roverCommandResult;
        }
    }
}
