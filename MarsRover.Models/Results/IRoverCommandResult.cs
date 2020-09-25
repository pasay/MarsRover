using MarsRover.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Results
{
    public interface IRoverCommandResult
    {
        string Verbose { get; set; }
        ResultType VerboseType { get; set; }
    }
}
