using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business.Domain.Constants
{
    public static class MessageConstant
    {
        public static string PlateauCreationAuthorization = "\nPlateau can only be produced by the manager.\n";
        public static string RoverCreationAuthorization = "\nRover can only be produced by the manager.\n";
        public static string RoverPlateauCoordinateFail = "\nCoordinate values entered for Rover do not match plateau boundaries. Please enter again\n";
        public static string MovementInstructionFail = "\nIncorrect movement command entered.\n";
        public static string NullParameterFail = "\nEmpty input error. Please enter again.\n";
        public static string MovementExceedsBoundariesFail = "\nThe Rover has reached the end point";
        public static string PlateauLimitsFail = "\nPlato boundaries entered are invalid. Please enter again.\n";
        public static string WrongInput = "\nWrong input. Please enter again\n";
    }
}
