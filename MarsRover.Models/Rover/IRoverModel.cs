using MarsRover.Models.Enums;

namespace MarsRover.Models.Rover
{
    public interface IRoverModel : IPointModel
    {
        DirectionType Direction { get; set; }
        IRoverModel Clone();
    }
}
