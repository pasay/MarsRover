using MarsRover.Models.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Planet.Imp
{
    public class RoverCommandModel : IRoverCommandModel
    {
        public List<IRoverCommand> RoverCommand { get; set; }
        public IPointModel UpperRight { get; set; }
    }
}
