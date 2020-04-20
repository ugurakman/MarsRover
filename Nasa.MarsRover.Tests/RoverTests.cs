using Moq;
using Nasa.MarsRover.Business;
using Nasa.MarsRover.Business.Domain.Constants;
using Nasa.MarsRover.Business.Domain.Enums;
using Nasa.MarsRover.Business.Domain.Models;
using Nasa.MarsRover.Business.Interfaces;
using Nasa.MarsRover.Business.Services;
using Xunit;


namespace Nasa.MarsRover.Tests
{
  public  class RoverTests
    {
        private IRover _rover;
        private IPlateau _plateau;

        public RoverTests()
        {
            _rover = new Rover();
            _plateau = new Mock<IPlateau>().Object;
        }

        [Fact]
        public void Correct_Movement()
        {
            _rover.X = 3;
            _rover.Y = 3;
            _rover.Direction = Compass.East;

            _plateau.LowerLeft = 5;
            _plateau.UpperRight = 5;

         
            _plateau.IsInPlateau(_rover);

            _rover.Plateau = _plateau;

            _rover.Move("MMRMMRMRRM");

            var result = _rover.Direction;
            var expectedResult = Compass.East;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Cleanup()
        {
            _rover = null;
            _plateau = null;

        }

    }
}
