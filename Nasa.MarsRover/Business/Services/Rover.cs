using Nasa.MarsRover.Business.Domain.Constants;
using Nasa.MarsRover.Business.Domain.Enums;
using Nasa.MarsRover.Business.Interfaces;
using System;
using System.Drawing;

namespace Nasa.MarsRover.Business.Services
{
    public class Rover : IRover, IMoveable
    {
        private IPlateau _plateau;
        private Point _coordinates;
        public Compass Direction { get; set; }
        public string ErrorMessage { get; set; }

        public int X
        {
            get { return _coordinates.X; }
            set { _coordinates.X = value; }
        }
        public int Y
        {
            get { return _coordinates.Y; }
            set { _coordinates.Y = value; }
        }
        public IPlateau Plateau
        {
            get { return _plateau; }
            set { _plateau = value; }
        }

        public Rover()
        {
        }

        public static IRover CreateRover(object createRequest)
        {
            if (createRequest is Manager)
            {
                return new Rover();
            }

            Console.WriteLine(MessageConstant.RoverCreationAuthorization);
            return null;

        }

        public bool Move(string movement)
        {
            var movementSteps = movement.ToCharArray();

            foreach (var movementStep in movementSteps)
            {

                switch (movementStep)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        MoveForward();
                        break;

                    default:
                        return false;

                }


            }

            return true;
        }

        private void TurnLeft()
        {
            Direction = (Compass)((int)Direction - 1);
            if ((int)Direction == -1)
            {
                Direction = Compass.West;
            }
        }

        private void TurnRight()
        {
            Direction = (Compass)(((int)Direction + 1) % 4);
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Compass.North:
                    _coordinates.Y++;
                    break;
                case Compass.South:
                    _coordinates.Y--;
                    break;
                case Compass.East:
                    _coordinates.X++;
                    break;
                case Compass.West:
                    _coordinates.X--;
                    break;
            }

            bool isInBoundaries = _plateau.IsInPlateau(this);

            if (!isInBoundaries)
            {
                switch (Direction)
                {
                    case Compass.North:
                        _coordinates.Y--;
                        break;
                    case Compass.South:
                        _coordinates.Y++;
                        break;
                    case Compass.East:
                        _coordinates.X--;
                        break;
                    case Compass.West:
                        _coordinates.X++;
                        break;
                }

            }


        }


    }
}
