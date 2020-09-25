using MarsRover.Models.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Commands.Rover.Imp
{
    public class RoverCommandItemListModel : IRoverCommandItemListModel
    {
        public List<IRoverCommandItemModel> RoverCommand { get; set; }
        public IPointModel UpperRight { get; set; }
    }
}
