using HepsiBuradaMarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaMarsRover.Helper
{
    public class MoveHelper
    {
        public void MoveAll(List<Move> moves)
        {
            foreach (var move in moves)
            {
                Process(move);
            }
        }

        private void Process(Move move)
        {
            foreach (var item in move.Directive)
            {
                if ((item == 'L') || (item == 'R'))
                {
                    Direction direction = new Direction();
                    direction = ProcessDirectionOrientation(item, move.Location.Direction);
                    move.Location.Direction = direction;
                }
                else if (item == 'M')
                    ProcessMoveOrientation(move);
                else
                    throw new Exception("Invalid Instruction Processed. Please supply only L,R and M");
            }
        }

        public void ProcessMoveOrientation(Move move)
        {
            CoordinateControl(move);
        }

        public Direction ProcessDirectionOrientation(char orientation, Direction direction)
        {
            int travelerDir = (int)direction;

            if (orientation == 'L')
            {
                if (travelerDir == 0)
                    travelerDir = 4;
                return (Direction)(travelerDir - 1);
            }
            else
            {
                if (travelerDir == 3)
                    travelerDir = -1;
                return (Direction)(travelerDir + 1);
            }

        }

        public void CoordinateControl(Move move)
        {
            if (move.Location.Direction.ToString() == "North")
                move.Location.Coordinate.YCoordinate++;

            else if (move.Location.Direction.ToString() == "South")
                move.Location.Coordinate.YCoordinate--;

            else if (move.Location.Direction.ToString() == "East")
                move.Location.Coordinate.XCoordinate++;

            else
                move.Location.Coordinate.XCoordinate--;
        }
    }
}
