using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    class Queen : BaseAnt
    {
        public override char Symbol => 'Q';

        public Queen(Colony colony, Position coords) : base(colony, coords)
        {

        }

    }
}
