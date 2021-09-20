using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaMarsRover.Model
{
    public class Move
    {
        public Location Location { get; set; }
        public string Directive { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
