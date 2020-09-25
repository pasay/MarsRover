using System.Collections.Generic;

namespace MarsRover.Models.Commands.Rover.Imp
{
    public class RoverCommandItemListModel : IRoverCommandItemListModel
    {
        public List<IRoverCommandItemModel> RoverCommand { get; set; }
        public IPointModel UpperRight { get; set; }
    }
}
