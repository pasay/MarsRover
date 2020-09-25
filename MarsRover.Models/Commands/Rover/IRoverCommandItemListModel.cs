using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Commands.Rover
{
    public interface IRoverCommandItemListModel
    {
        List<IRoverCommandItemModel> RoverCommand { get; set; }
        IPointModel UpperRight { get; set; }
    }
}
