using HepsiBuradaMarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaMarsRover.Helper
{
    public class CoordinateHelper
    {
        public CoordinateControl CheckFieldSize(string fieldSize)
        {
            CoordinateControl coordinateControl = new CoordinateControl();
            coordinateControl.IsSuccess = false;

            string[] splitFieldSize = fieldSize.Split(' ');
            if(splitFieldSize.Length != 2)
            {
                coordinateControl.Message = "Wrong Enter - Uzunluk hatası";
                return coordinateControl;
            }

            int xCoordinate;
            int yCoordinate;

            bool xCoordinateChecker;
            bool yCoordinateChecker;

            xCoordinateChecker = int.TryParse(splitFieldSize[0], out xCoordinate);
            yCoordinateChecker = int.TryParse(splitFieldSize[1], out yCoordinate);

            if(!xCoordinateChecker || !yCoordinateChecker)
            {
                coordinateControl.Message = "Wrong Enter - Rakam girmeme hatası"; 
                return coordinateControl;
            }

            Coordinate coordinate = new Coordinate();
            coordinate.XCoordinate = Convert.ToInt32(splitFieldSize[0]);
            coordinate.YCoordinate = Convert.ToInt32(splitFieldSize[1]);
            coordinateControl.Coordinate = coordinate;
            coordinateControl.IsSuccess = true;

            return coordinateControl;
        }
    }
}
