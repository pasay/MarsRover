using MarsRover.Models.Rover;

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
