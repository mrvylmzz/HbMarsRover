using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaMarsRover.Model
{
    public class Location
    {
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West,
        Undefined
    }

    public class LocationControl : BaseMessage
    {
        public Location Location { get; set; }
    }

    public class DirectionControl : BaseMessage
    {
        public Direction Direction { get; set; }
    }
}
