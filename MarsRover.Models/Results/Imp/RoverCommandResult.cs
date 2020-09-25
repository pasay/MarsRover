using MarsRover.Models.Enums;

namespace MarsRover.Models.Results.Imp
{
    public class RoverCommandResult : IRoverCommandResult
    {
        public string Verbose { get; set; }

        public ResultType VerboseType { get; set; }
    }
}
