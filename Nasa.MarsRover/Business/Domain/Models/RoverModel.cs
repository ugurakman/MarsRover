using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business.Domain.Models
{
    public class RoverModel
    {
        public char Direction { get; set; }
        public string Movement { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string ErrorTracer { get; set; }
        public PlateauModel Plateau { get; set; }
    }
}
