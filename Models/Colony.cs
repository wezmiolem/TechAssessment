using System;
using System.Collections.Generic;
using System.Text;

namespace TechAssessment.Models
{
    public class Colony
    {
        public int Width { get; }

        public BaseAnt[,] _ants;

        public Colony(int width)
        {
            Width = width;
            _ants = new BaseAnt[Width, Width];
        }
    }
}
