using Nasa.MarsRover.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business.Interfaces
{
    public interface IManager
    {
        IRover RoverInstance { get; set; }
        IPlateau PlateausInstance { get; set; }
        string GetRoverStatus();
        void MoveRover(RoverModel request);
        void PreparePlateau(PlateauModel request);
        void PrepareRover(RoverModel request);
    }
}
