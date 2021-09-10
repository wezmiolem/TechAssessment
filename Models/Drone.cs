using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public class Drone : BaseAnt
    {
        private int _cooldownCounter;
        public override char Symbol => 'D';

        public Drone(Colony colony, Position coords) : base(colony, coords)
        {
            _cooldownCounter = 0;
        }

        public override void OnUpdate()
        {
            if (_cooldownCounter > 0)
            {
                _cooldownCounter--;
                if (_cooldownCounter == 0)
                    KickAway();
            }
            else
            {
                Position queenPosition = Colony.QueenOfColony.Coords;
                if (Position.Distance(Coords, queenPosition) == 1)
                {
                    Colony.QueenOfColony.AskToMate(this);
                }
                else
                {
                    MoveTowardsQueen(queenPosition);
                }
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
        public void KickAway()
        {
            Position[] edgePositions = Colony.GetAvailableEdgePositions();
            Position targetPosition = edgePositions[Extensions.Random.Next(0, edgePositions.Length)];
            Colony.TryMove(this, targetPosition);
        }
        public void Mate()
        {
            Console.WriteLine("HALLELUJAH");
            _cooldownCounter = 10;
        }
    }
}
