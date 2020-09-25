using MarsRover.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Planet.Imp
{
    public class RoverCommandResult : IRoverCommandResult
    {
        public string Verbose { get; set; }

        public ResultType VerboseType { get; set; }
    }
}
