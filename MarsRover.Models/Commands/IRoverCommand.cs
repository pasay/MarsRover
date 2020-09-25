using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Commands
{
    public interface IRoverCommand 
    {
        IRoverModel RoverModel { get; set; }
        MoveListModel MoveListModel { get; set; }
        IRoverCommand Clone();
    }
}
