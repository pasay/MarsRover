using MarsRover.Models.Enums;

namespace MarsRover.Models.Results
{
    public interface IRoverCommandResult
    {
        string Verbose { get; set; }
        ResultType VerboseType { get; set; }
    }
}
