using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public class Queen : BaseAnt
    {
        private int _moodCounter;
        public override char Symbol => 'Q';

        public Queen(Colony colony, Position coords) : base(colony, coords)
        {
            ResetMoodCounter();
        }

        public override void OnUpdate()
        {
            if (_moodCounter > 0)
                _moodCounter--;
        }
        private void ResetMoodCounter()
        {
            _moodCounter = Extensions.Random.Next(50, 101);
        }
        public void AskToMate(Drone drone)
        {
            if (_moodCounter > 0)
            {
                Console.WriteLine(":(");
                drone.KickAway();
            }
            else
            {
                drone.Mate();
                ResetMoodCounter();
            }
        }
    }
}
