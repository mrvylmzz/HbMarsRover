using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaMarsRover.Model
{
    public class Coordinate
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }

    public class CoordinateControl : BaseMessage
    {
        public Coordinate Coordinate { get; set; }
    }
}
