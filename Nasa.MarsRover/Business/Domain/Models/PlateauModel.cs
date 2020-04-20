using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business.Domain.Models
{
    public class PlateauModel
    {
        public int UpperRight { get; set; }
        public int LowerLeft { get; set; }
        public string ErrorTracer { get; set; }
    }
}
