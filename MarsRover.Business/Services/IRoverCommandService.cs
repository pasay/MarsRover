using MarsRover.Models.Commands;
using MarsRover.Models.Commands.Rover;
using MarsRover.Models.Enums;
using MarsRover.Models.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business.Services
{
    public interface IRoverCommandService
    {
        IRoverCommandItemListModel RoverCommandItemListModel { get; set; }
        List<IRoverCommandResult> Run();
        IRoverCommandResult Move(IRoverCommandItemModel rover, MoveType moveItem);
    }
}
