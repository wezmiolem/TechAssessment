using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public class Drone : BaseAnt
    {
        public override char Symbol => 'D';

        public Drone(Colony colony, Position coords) : base(colony, coords)
        {

        }

        public override void OnUpdate()
        {
            Position queenPosition = Colony.QueenOfColony.Coords;
            if (Position.Distance(Coords, queenPosition) == 1)
            {
                
            }
            else
            {
                MoveTowardsQueen(queenPosition);
            }
        }
        public void MoveTowardsQueen(Position queenPosition)
        {
            Direction moveDirection;

            if (Coords.X == queenPosition.X)
            {
                if (Coords.Y > queenPosition.Y)
                {
                    moveDirection = Direction.North;
                }
                else
                {
                    moveDirection = Direction.South;
                }
            }
            else
            {
                if (Coords.X > queenPosition.X)
                {
                    moveDirection = Direction.West;
                }
                else
                {
                    moveDirection = Direction.East;
                }
            }
            Position targetPosition = Coords.MoveTowards(moveDirection);
            Colony.TryMove(this, targetPosition);
        }
    }
}
