using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class DirectionException : Exception
    {
        public DirectionException(char direction) : base($"The direction {direction} is invalid. Please try again using N, E, S, W.")
        {
            Direction = direction;
        }

        public char Direction { get; set; }
    }
}
