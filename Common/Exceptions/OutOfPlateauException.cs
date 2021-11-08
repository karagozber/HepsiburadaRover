using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class OutOfPlateauException : Exception
    {
        public OutOfPlateauException(int xLimit, int yLimit) : base($"Location that you entered is not on plateau.")
        {
            XLimit = xLimit;
            YLimit = yLimit;
        }

        public int XLimit { get; set; }
        public int YLimit { get; set; }
    }
}
