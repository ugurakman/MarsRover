using Nasa.MarsRover.Business.Domain.Constants;
using Nasa.MarsRover.Business.Domain.Models;
using Nasa.MarsRover.Business.Extensions;
using Nasa.MarsRover.Business.Interfaces;
using Nasa.MarsRover.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business
{ /// <summary>
  /// Manages rover and Plateau operations and abstracts all classes and operations from user.
  /// </summary>
    public class Manager : IManager
    {
        private IRover _rover;
        private IPlateau _plateaus;

        public IRover RoverInstance
        {
            get { return _rover; }
            set { _rover = value; }
        }
        public IPlateau PlateausInstance
        {
            get { return _plateaus; }
            set { _plateaus = value; }
        }

        public string GetRoverStatus()
        {
            return "\nX: " + _rover.X + "\nY: " + _rover.Y + "\nDirection : " + _rover.Direction + "\n" + _rover.ErrorMessage;
        }


        public void MoveRover(RoverModel model)
        {
            if (model.ErrorTracer == null)
            {
                var result = _rover.Move(model.Movement.ToUpper());
                _rover.ErrorMessage = !result ? MessageConstant.MovementInstructionFail : null;
            }


        }

        public void PreparePlateau(PlateauModel model)
        {
            if (model.ErrorTracer == null)
            {
                _plateaus = Plateau.CreatePlateau(this);

                if (model.UpperRight <= 0 && model.LowerLeft <= 0)
                {
                    _plateaus.ErrorMessage = MessageConstant.PlateauLimitsFail;
                }

                _plateaus.LowerLeft = model.LowerLeft;
                _plateaus.UpperRight = model.UpperRight;


            }
        }

        public void PrepareRover(RoverModel model)
        {

            if (model.ErrorTracer == null)
            {
                _rover = Rover.CreateRover(this);
                _rover.X = model.X;
                _rover.Y = model.Y;
                _rover.Direction = EnumConvertor.ConvertCharToDirection(model);
                _rover.Plateau = _plateaus;

                if (model.X < 0 || model.X < 0)
                {
                    _rover.ErrorMessage = MessageConstant.RoverPlateauCoordinateFail;
                }


                if (model.Plateau.UpperRight < model.X || model.Plateau.LowerLeft < model.X)
                {
                    _rover.ErrorMessage = MessageConstant.RoverPlateauCoordinateFail;
                }

                if (model.Plateau.UpperRight < model.Y || model.Plateau.LowerLeft < model.Y)
                {
                    _rover.ErrorMessage = MessageConstant.RoverPlateauCoordinateFail;
                }
            }
        }


    }
}
