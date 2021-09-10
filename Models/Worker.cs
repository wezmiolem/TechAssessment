using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public class Worker : BaseAnt
    {
        public override char Symbol => 'W';

        public Worker(Colony colony, Position coords) : base(colony, coords)
        {

        }

        public override void OnUpdate()
        {
            Direction randomDirection = Extensions.GetRandomDirection();
            Position targetPosition = Coords.MoveTowards(randomDirection);
            Colony.TryMove(this, targetPosition);
        }
    }
}
