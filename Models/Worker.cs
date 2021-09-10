using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    class Worker : BaseAnt
    {
        public override char Symbol => 'W';

        public Worker(Colony colony, Position coords) : base(colony, coords)
        {

        }
    }
}
