using MarsRover.Models.Commands;
using MarsRover.Models.Enums;
using MarsRover.Models.Planet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business
{
    public interface IRoverCommandService
    {
        IRoverCommandModel RoverCommandModel { get; set; }
        List<IRoverCommandResult> Run();
        IRoverCommandResult Move(IRoverCommand rover, MoveType moveItem);
    }
}
