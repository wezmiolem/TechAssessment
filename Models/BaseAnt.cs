using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public abstract class BaseAnt
    {
        public Position Coords { get; set; }

        protected Colony Colony { get; }

        protected BaseAnt(Colony colony, Position coords)
        {
            Colony = colony;
            Coords = coords;
        }
    }
}
