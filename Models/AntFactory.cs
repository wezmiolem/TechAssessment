using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public static class AntFactory
    {
        public static Queen GetQueen(Colony colony)
        {
            Position center = new Position(colony.Width / 2, colony.Width / 2);
            Queen queen = new Queen(colony, center);
            colony.Move(queen, center);
            return queen;
        }
        public static List<BaseAnt> GenerateAnts(Colony colony, int workers, int drones, int soldiers)
        {
            List<Position> positions = colony.AvailablePositions().ToList();

            Position getRandomPosition()
            {
                Position randomPosition = positions[Extensions.Random.Next(0, positions.Count)];
                positions.Remove(randomPosition);
                return randomPosition;
            }
            List<BaseAnt> ants = new List<BaseAnt>();
            for (int i = 0; i < workers; i++)
            {
                ants.Add(new Worker(colony, getRandomPosition()));
            }
            for (int i = 0; i < drones; i++)
            {
                ants.Add(new Drone(colony, getRandomPosition()));
            }
            for (int i = 0; i < soldiers; i++)
            {
                ants.Add(new Soldier(colony, getRandomPosition()));
            }
            return ants;
        }
    }
}
