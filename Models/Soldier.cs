using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    class Soldier : BaseAnt
    {
        public override char Symbol => 'S';

        public Soldier(Colony colony, Position coords) : base(colony, coords)
        {

        }
    }
}
