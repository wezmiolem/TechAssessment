﻿using System;
using System.Collections.Generic;
using System.Text;
using TechAssessment.Utils;

namespace TechAssessment.Models
{
    public class Colony
    {
        public int Width { get; }

        public BaseAnt[,] _ants;
        public Queen QueenOfColony { get; }

        public Colony(int width, int workers, int drones, int soldiers)
        {
            Width = width;
            _ants = new BaseAnt[Width, Width];
            QueenOfColony = AntFactory.GetQueen(this);
            AntFactory.GetAnts(this, workers, drones, soldiers);
        }
        public void Move(BaseAnt ant, Position targetPosition, bool emptyOldPosition=false)
        {
            if (emptyOldPosition)
            {
                _ants[ant.Coords.Y, ant.Coords.X] = null;
            }
            _ants[targetPosition.Y, targetPosition.X] = ant;
            ant.Coords = targetPosition;
        }

        public bool IsSpotAvailable(Position coords)
        {
            if (coords.X < 0 || coords.X > Width - 1 || coords.Y < 0 || coords.Y > Width - 1)
                return false;
            return _ants[coords.Y, coords.X] == null;

        }
        public void TryMove(BaseAnt ant, Position position)
        {
            if (!IsSpotAvailable(position))
                return;
            Move(ant, position, true);
        }
        public Position[] AvailablePositions()
        {
            List<Position> availablePositions = new List<Position>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    if (_ants[y, x] == null)
                        availablePositions.Add(new Position(x, y));
                }
            }
            return availablePositions.ToArray();
        }
    }
}
