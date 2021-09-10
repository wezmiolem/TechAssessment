using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    class Drone : BaseAnt
    {
        public override char Symbol => 'D';

        public Drone(Colony colony, Position coords) : base(colony, coords)
        {

        }
    }
}
