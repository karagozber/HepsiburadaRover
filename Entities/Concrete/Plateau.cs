using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Plateau : IEntity
    {
        public int XLimit { get; set; }
        public int YLimit { get; set; }
        public Plateau(int xLimit, int yLimit)
        {
            XLimit = xLimit;
            YLimit = yLimit;
        }
    }
}
