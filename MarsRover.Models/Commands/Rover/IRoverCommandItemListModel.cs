using System.Collections.Generic;

namespace MarsRover.Models.Commands.Rover
{
    public interface IRoverCommandItemListModel
    {
        List<IRoverCommandItemModel> RoverCommand { get; set; }
        IPointModel UpperRight { get; set; }
    }
}
