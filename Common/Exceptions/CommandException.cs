using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(char command) : base($"Command {command} is invalid. Please use L, M or R and try again.")
        {
            Command = command;
        }
        public char Command { get; set; }
    }
}
