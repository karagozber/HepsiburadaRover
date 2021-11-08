using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Location : IEntity
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
    }
}
