using System;
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
            AntFactory.GenerateAnts(this, workers, drones, soldiers);
        }
        public void Move(BaseAnt ant, Position targetPosition, bool emptyOldPosition = false)
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
        public Position[] GetAvailableEdgePositions()
        {
            List<Position> availableEdgePositions = new List<Position>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    if (x == 0 || x == Width - 1 || y == 0 || y == Width - 1)
                    {
                        if (_ants[y, x] == null)
                            availableEdgePositions.Add(new Position(x, y));
                    }
                }
            }
            return availableEdgePositions.ToArray();
        }
        public void Update()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    BaseAnt ant = _ants[y, x];
                    if (ant != null)
                    {
                        ant.OnUpdate();
                    }
                }
            }
        }
        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    BaseAnt ant = _ants[y, x];
                    if (ant == null)
                        sb.Append(' ');
                    else
                        sb.Append(ant.Symbol);
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
