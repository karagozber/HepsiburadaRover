using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class CollisionException : Exception
    {
        public CollisionException() : base("There is already a rover in that location.")
        {
            
        }
    }
}
