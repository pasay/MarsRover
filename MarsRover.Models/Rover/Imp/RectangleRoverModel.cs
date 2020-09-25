using MarsRover.Models.Enums;

namespace MarsRover.Models.Rover.Imp
{
    public class RectangleRoverModel : IRoverModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionType Direction { get; set; }

        public IRoverModel Clone()
        {
            return (IRoverModel)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{X} {Y} {Direction.ToString()}";
        }
    }
}
