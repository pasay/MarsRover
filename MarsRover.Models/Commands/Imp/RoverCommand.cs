using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Commands.Imp
{
    public class RoverCommand : IRoverCommand
    {
        public IRoverModel RoverModel { get; set; }
        public MoveListModel MoveListModel { get; set; }

        public IRoverCommand Clone()
        {
            return (RoverCommand)this.MemberwiseClone();
        }
    }
}
