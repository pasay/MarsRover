using MarsRover.Models.Rover;

namespace MarsRover.Models.Commands.Rover
{
    public interface IRoverCommandItemModel
    {
        IRoverModel RoverModel { get; set; }
        MoveListModel MoveListModel { get; set; }
        IRoverCommandItemModel Clone();
    }
}
