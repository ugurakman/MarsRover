using Nasa.MarsRover.Business.Domain.Constants;
using Nasa.MarsRover.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business.Services
{
    public class Plateau : IPlateau
    {
        public int UpperRight { get; set; }
        public int LowerLeft { get; set; }
        public string ErrorMessage { get; set; }

        public Plateau()
        {

        }

        public static IPlateau CreatePlateau(object createRequest)
        {


            if (createRequest is Manager)
            {
                return new Plateau();
            }

            Console.WriteLine(MessageConstant.PlateauCreationAuthorization);

            return null;
        }

        public bool IsInPlateau(IRover rover)
        {
            var roverPlato = rover.Plateau;

            if (rover.X > roverPlato.UpperRight ||rover.Y > roverPlato.LowerLeft ||
                rover.X < 0 || rover.Y < 0
            )
            {
                rover.ErrorMessage = MessageConstant.MovementExceedsBoundariesFail;

                return false;
            }

            return true;
        }


    }
}
