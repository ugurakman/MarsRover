using Nasa.MarsRover.Business.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business.Interfaces
{
    public interface IRover
    {
        bool Move(string movement);
        int X { get; set; }
        int Y { get; set; }
        IPlateau Plateau { get; set; }
        Compass Direction { get; set; }
        string ErrorMessage { get; set; }
    }
}
