using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Business.Interfaces
{
    public interface IPlateau
    {
        bool IsInPlateau(IRover rover);
        int UpperRight { get; set; }
        int LowerLeft { get; set; }
        string ErrorMessage { get; set; }
    }
}
