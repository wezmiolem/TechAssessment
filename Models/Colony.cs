using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

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

        public void Move(BaseAnt ant, Position targetPosition)
        {
            _ants[targetPosition.Y, targetPosition.X] = ant;
            ant.Coords = targetPosition;
        }
    }
}
