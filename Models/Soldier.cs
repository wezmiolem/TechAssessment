using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public class Soldier : BaseAnt
    {
        public override char Symbol => 'S';
        private Direction _currentDirection;

        public Soldier(Colony colony, Position coords) : base(colony, coords)
        {
            _currentDirection = Direction.North;
        }

        public override void OnUpdate()
        {
            Position targetPosition = Coords.MoveTowards(_currentDirection);
            Colony.TryMove(this, targetPosition);
            _currentDirection = Extensions.RotateLeft(_currentDirection);
        }
    }
}
