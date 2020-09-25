using MarsRover.Models.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Planet
{
    public interface IRoverCommandModel
    {
        List<IRoverCommand> RoverCommand { get; set; }
        IPointModel UpperRight { get; set; }
    }
}
