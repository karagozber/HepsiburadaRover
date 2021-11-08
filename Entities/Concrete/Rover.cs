using Common;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rover : IEntity
    {
        public Rover(Location location, char direction)
        {
            Location = location;
            Direction = direction;
        }

        public Location Location { get; set; }
        public char Direction { get; set; }
        public RoverDirection RoverDirection { get; set; }

    }
}
