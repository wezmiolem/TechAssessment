using System;
using System.Collections.Generic;
using System.Text;

namespace TechAssessment.Utils
{
    public struct Position
    {
        public int X { get; }

        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Position MoveTowards(Direction direction, int steps = 1)
        {
            int stepX = direction switch
            {
                Direction.East => 1,
                Direction.West => -1,
                _ => 0
            };
            int stepY = direction switch
            {
                Direction.North => -1,
                Direction.South => 1,
                _ => 0
            };
            return new Position(this.X + stepX * steps, this.Y + stepY * steps);
        }
        public static int Distance(Position a, Position b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
    
