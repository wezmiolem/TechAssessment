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
        public static Direction RotateLeft(Direction direction) => direction switch
        {
            Direction.North => Direction.West,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            Direction.West => Direction.South,
            _ => throw new ArgumentOutOfRangeException()

        };

    }
}
