using System;
using System.Collections.Generic;
using System.Text;

namespace TechAssessment.Utils
{
    public static class Extensions
    {
        public static readonly Random Random = new Random();
        public static Direction GetRandomDirection()
        {
            Direction[] allDirections = (Direction[])Enum.GetValues(typeof(Direction));
            return allDirections[Random.Next(0, allDirections.Length)];
        }

    }
}
