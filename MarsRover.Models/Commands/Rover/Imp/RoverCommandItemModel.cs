using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Commands.Rover.Imp
{
    public class RoverCommandItemModel : IRoverCommandItemModel
    {
        public IRoverModel RoverModel { get; set; }
        public MoveListModel MoveListModel { get; set; }

        public IRoverCommandItemModel Clone()
        {
            return (RoverCommandItemModel)this.MemberwiseClone();
        }
    }
}
