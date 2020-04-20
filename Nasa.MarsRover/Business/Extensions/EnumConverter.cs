using Nasa.MarsRover.Business.Domain.Constants;
using Nasa.MarsRover.Business.Domain.Enums;
using Nasa.MarsRover.Business.Domain.Models;
using System;

namespace Nasa.MarsRover.Business.Extensions
{
    public static class EnumConvertor
    {
        public static Compass ConvertCharToDirection(RoverModel model)
    {
        Compass direction = Compass.North;

        switch (Char.ToUpper(model.Direction))
        {

            case 'N':
                direction = Compass.North;
                break;
            case 'E':
                direction = Compass.East;
                break;
            case 'W':
                direction = Compass.West;
                break;
            case 'S':
                direction = Compass.South;
                break;
            default:
                model.ErrorTracer = MessageConstant.WrongInput;
                break;

        }

        return direction;
        }
    }
}
