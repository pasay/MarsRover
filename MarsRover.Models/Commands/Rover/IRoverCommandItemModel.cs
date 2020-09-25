using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Commands.Rover
{
    public interface IRoverCommandItemModel 
    {
        IRoverModel RoverModel { get; set; }
        MoveListModel MoveListModel { get; set; }
        IRoverCommandItemModel Clone();
    }
}
