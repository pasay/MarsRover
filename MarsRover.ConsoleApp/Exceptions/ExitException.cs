using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.ConsoleApp.Exceptions
{
    public class ExitException : Exception
    {
        public ExitException() : this(ConsoleApp.Properties.Resources.ExitSignalDetected)
        {
        }
        public ExitException(string message) : base(message)
        {
        }

        public ExitException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
