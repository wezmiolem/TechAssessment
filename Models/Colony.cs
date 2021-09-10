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

        public bool IsSpotAvailable(Position coords)
        {
            if (coords.X < 0 || coords.X > Width - 1 || coords.Y < 0 || coords.Y > Width - 1)
                return false;
            return _ants[coords.Y, coords.X] == null;

        }
    }
}
