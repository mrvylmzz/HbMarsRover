using HepsiBuradaMarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaMarsRover.Helper
{
    public class LocationHelper
    {
        public LocationControl CheckLocation(string location)
        {
            LocationControl locationControl = new LocationControl();
            locationControl.IsSuccess = false;

            string[] splitLocation = location.Split(' ');
            if (splitLocation.Length != 3)
            {
                locationControl.Message = "Wrong Enter - Uzunluk hatası";
                return locationControl;
            }

            int xCoordinate;
            int yCoordinate;

            bool xCoordinateChecker;
            bool yCoordinateChecker;

            xCoordinateChecker = int.TryParse(splitLocation[0], out xCoordinate);
            yCoordinateChecker = int.TryParse(splitLocation[1], out yCoordinate);

            if(!xCoordinateChecker || !yCoordinateChecker)
            {
                locationControl.Message = "Wrong Enter - Rakam girmeme hatası";
                return locationControl;
            }

            char way = Convert.ToChar(splitLocation[2]);
            DirectionControl returnDirection = GetDirection(way);
            if(returnDirection.Direction == Direction.Undefined)
            {
                locationControl.Message = returnDirection.Message;
                return locationControl;
            }

            Location returnLocation = new Location();

            Coordinate returnCoordinate = new Coordinate();
            returnCoordinate.XCoordinate = Convert.ToInt32(splitLocation[0]);
            returnCoordinate.YCoordinate = Convert.ToInt32(splitLocation[1]);

            returnLocation.Coordinate = returnCoordinate;
            returnLocation.Direction = returnDirection.Direction;

            locationControl.Location = returnLocation;
            locationControl.IsSuccess = true;


            return locationControl;
        }


        private DirectionControl GetDirection(char way)
        {
            DirectionControl directionControl = new DirectionControl();
            directionControl.IsSuccess = true;
            switch (way)
            {
                case 'N':
                    directionControl.Direction = Direction.North;
                    return directionControl;
                case 'S':
                    directionControl.Direction = Direction.South;
                    return directionControl;
                case 'E':
                    directionControl.Direction = Direction.East;
                    return directionControl;
                case 'W':
                    directionControl.Direction = Direction.West;
                    return directionControl;
                default:
                    directionControl.Direction = Direction.Undefined;
                    directionControl.IsSuccess = false;
                    directionControl.Message = "Unknown Direction Supplied. Accepted values are N,S,E,W";
                    return directionControl;
            }
        }
    }
}
