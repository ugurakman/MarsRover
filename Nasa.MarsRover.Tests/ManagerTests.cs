using Moq;
using Nasa.MarsRover.Business;
using Nasa.MarsRover.Business.Domain.Constants;
using Nasa.MarsRover.Business.Domain.Models;
using Nasa.MarsRover.Business.Interfaces;
using Xunit;

namespace Nasa.MarsRover.Tests
{
    public class ManagerTests
    {
        private Manager _manager;
        private IRover _mockedRover;
        private IPlateau _mockedPlateau;
        public ManagerTests()
        {
            _manager = new Manager();
            _mockedRover = new Mock<IRover>().Object;
            _mockedPlateau = new Mock<IPlateau>().Object;
        }


        [Fact]
        public void Create_Valid_Plateau()
        {
            var model = new PlateauModel();
            model.LowerLeft = 10;
            model.UpperRight = 5;

            _manager.PreparePlateau(model);

            var result = model.ErrorTracer;

            Assert.Null(result);
        }

        [Fact]
        public void Create_Invalid_Plateau()
        {
            var model = new PlateauModel();
            model.LowerLeft = -1;
            model.UpperRight = -1;

            _manager.PreparePlateau(model);

            var result = model.ErrorTracer;
            var exceptedResult = MessageConstant.PlateauLimitsFail;

            Assert.NotEqual(exceptedResult, result);
        }
        [Fact]
        public void Create_Zero_Plateau()
        {
            var model = new PlateauModel();
            model.LowerLeft = 0;
            model.UpperRight = 0;

            _manager.PreparePlateau(model);
            var result = _manager.PlateausInstance.ErrorMessage;
            var exceptedResult = MessageConstant.PlateauLimitsFail;

            Assert.Equal(exceptedResult, result);
        }

        [Fact]
        public void Generate_Rover_In_Plateau()
        {
            RoverModel roverModel = new RoverModel();

            roverModel.Direction = 'N';
            roverModel.X = 3;
            roverModel.Y = 3;

            var plateauModel = new PlateauModel();
            plateauModel.LowerLeft = 5;
            plateauModel.UpperRight = 5;

            roverModel.Plateau = plateauModel;

            _manager.PrepareRover(roverModel);

            var result = roverModel.ErrorTracer;

            Assert.Null(result);
        }

        [Fact]
        public void Generate_Rover_Out_Of_Plateau()
        {
            RoverModel roverModel = new RoverModel();

            roverModel.Direction = 'N';
            roverModel.X = 6;
            roverModel.Y = 6;

            var plateauModel = new PlateauModel();
            plateauModel.LowerLeft = 5;
            plateauModel.UpperRight = 5;

            roverModel.Plateau = plateauModel;

            _manager.PrepareRover(roverModel);

            var result = _manager.RoverInstance.ErrorMessage;
            var exceptedResult = MessageConstant.RoverPlateauCoordinateFail;

            Assert.Equal(exceptedResult, result);
        }

        [Fact]
        public void Generate_Rover_Out_Of_Plateau_as_Negative()
        {
            var roverModel = new RoverModel();

            roverModel.Direction = 'N';
            roverModel.X = -1;
            roverModel.Y = -1;

            var plateauModel = new PlateauModel();
            plateauModel.LowerLeft = 5;
            plateauModel.UpperRight = 5;

            roverModel.Plateau = plateauModel;

            _manager.PrepareRover(roverModel);

            var result = _manager.RoverInstance.ErrorMessage;
            var exceptedResult = MessageConstant.RoverPlateauCoordinateFail;

            Assert.Equal(exceptedResult, result);
        }

        [Fact]
        public void Correct_Move_Instruction()
        {
            RoverModel rover = new RoverModel();
            rover.Movement = "LMLMLMLLMM";

            _manager.RoverInstance = _mockedRover;

            _manager.MoveRover(rover);

            var result = rover.ErrorTracer;

            Assert.Null(result);
        }

        [Fact]
        public void Cleanup()
        {
            _manager = null;
            _mockedPlateau = null;
            _mockedRover = null;
        }
    }
}
