using HepsiBuradaMarsRover.Helper;
using HepsiBuradaMarsRover.Model;
using System;
using System.Collections.Generic;

namespace HepsiBuradaMarsRover
{
    class Program
    {
        static void Main(string[] args)
        {      
            Console.WriteLine("Enter right-upper coordinate information: ");
            string fieldSize = Console.ReadLine();
            CoordinateHelper coordinateHelper = new CoordinateHelper();
            CoordinateControl coordinateControl = coordinateHelper.CheckFieldSize(fieldSize);

            if (!coordinateControl.IsSuccess)
            {
                Console.WriteLine(coordinateControl.Message);
                return;
            }

            Console.WriteLine("How many robot will move?: ");
            string robot = Console.ReadLine();
            int robotCount;
            bool robotCountChecker;
            robotCountChecker = int.TryParse(robot, out robotCount);
            if (!robotCountChecker)
            {
                Console.WriteLine("Enter number");
                return;
            }

            List<Move> moves = new List<Move>();
            for (int i = 1; i <= robotCount; i++)
            {
                Console.WriteLine("Enter {0}. robot's location: ", i);
                string robotLocation = Console.ReadLine();
                LocationHelper locationHelper = new LocationHelper();
                LocationControl locationControl = locationHelper.CheckLocation(robotLocation);

                if (!locationControl.IsSuccess)
                {
                    Console.WriteLine(locationControl.Message);
                    return;
                }

                Console.WriteLine("Enter {0}. robot's directive: ", i);
                string robotDirective = Console.ReadLine();
                DirectiveHelper directiveHelper = new DirectiveHelper();
                DirectiveControl directiveControl = directiveHelper.CheckDirective(robotDirective.ToUpper());
                if (!directiveControl.IsSuccess)
                    Console.WriteLine(directiveControl.Message);

                Move move = new Move();
                move.Coordinate = coordinateControl.Coordinate;
                move.Location = locationControl.Location;
                move.Directive = robotDirective;

                moves.Add(move);
            }

            MoveHelper moveHelper = new MoveHelper();
            moveHelper.MoveAll(moves);

            for (int i = 1; i <= robotCount; i++)
            {
                Console.WriteLine("{0}. robot's new location : " + moves[i - 1].Location.Coordinate.XCoordinate + " " + moves[i - 1].Location.Coordinate.YCoordinate + " " + moves[i - 1].Location.Direction, i);
            }

            Console.ReadLine();


        }
    }
}
