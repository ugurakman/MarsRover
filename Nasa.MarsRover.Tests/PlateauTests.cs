using Moq;
using Nasa.MarsRover.Business;
using Nasa.MarsRover.Business.Domain.Constants;
using Nasa.MarsRover.Business.Domain.Models;
using Nasa.MarsRover.Business.Interfaces;
using Nasa.MarsRover.Business.Services;
using Xunit;

namespace Nasa.MarsRover.Tests
{

    public class PlateauTests
    {
        private IPlateau _plateau;
        private IRover _mockedRover;
        public PlateauTests()
        {
            _mockedRover = new Mock<IRover>().Object;
            _plateau = new Plateau();
            _mockedRover = new Mock<IRover>().Object;
        }

        [Fact]
        public void Drive_Rover_Into_Place()
        {
            var rover = new Rover();
            rover.X = 1;
            rover.Y = 1;

            _plateau.UpperRight = 4;
            _plateau.LowerLeft = 4;

            rover.Plateau = _plateau;

            bool result = _plateau.IsInPlateau(rover);
            bool expectedResult = true;

            Assert.Equal(expectedResult, result);
        }
       
        [Fact]
        public void Drive_Rover_In_The_Out_Of_Border()
        {
            var rover = new Rover();
            rover.X = 5;
            rover.Y = 5;

            _plateau.UpperRight = 4;
            _plateau.LowerLeft = 4;

            rover.Plateau = _plateau;

            bool result = _plateau.IsInPlateau(rover);
            bool expectedResult = false;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Drive_Rover_In_The_Edge_Of_Border()
        {
            var rover = new Rover();
            rover.X = 5;
            rover.Y = 5;

            _plateau.UpperRight = 5;
            _plateau.LowerLeft = 5;

            rover.Plateau = _plateau;

            bool result = _plateau.IsInPlateau(rover);
            bool expectedResult = true;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Drive_Rover_In_The_Negative_Side_Of_Border()
        {
            var rover = new Rover();
            rover.X = -5;
            rover.Y = -5;

            _plateau.UpperRight = 4;
            _plateau.LowerLeft = 4;

            rover.Plateau = _plateau;

            bool result = _plateau.IsInPlateau(rover);
            bool expectedResult = false;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Cleanup()
        {
            _plateau = null;
            _mockedRover = null;
        }



    }


}
