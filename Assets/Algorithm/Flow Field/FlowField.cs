using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class FlowField
    {
        public Cell[,] Grid { get; private set; } = null;
        public Vector2Int GridSize { get; private set; } = Vector2Int.zero;
        public float CellRadius { get; private set; } = 0.0f;
        public Cell destinationCell;

        private float _cellDiameter = 0.0f;

        public FlowField(float _cellRadius, Vector2Int _gridSize)
        {
            CellRadius = _cellRadius;
            _cellDiameter = CellRadius * 2f;
            GridSize = _gridSize;
        }

        public void CreateGrid()
        {
            Grid = new Cell[GridSize.y, GridSize.x];

            for (int y = 0; y < GridSize.y; y++)
            {
                for (int x = 0; x < GridSize.x; x++)
                {
                    Vector3 worldPos = new Vector3(_cellDiameter * x + CellRadius, 0, _cellDiameter * -y - CellRadius);
                    worldPos += new Vector3(GridSize.x / -2f, 0f, GridSize.y / 2f);
                    Grid[y, x] = new Cell(worldPos, new Vector2Int(y, x));
                }
            }
        }

        public void CreateCostField()
        {
            Vector3 cellHalfExtents = Vector3.one * CellRadius;
            int terrainMask = LayerMask.GetMask("Impassible", "RoughTerrain");

            foreach (Cell curCell in Grid)
            {
                Collider[] obstacles = Physics.OverlapBox(curCell.WorldPos, cellHalfExtents, Quaternion.identity, terrainMask);
                bool hasIncreasedCost = false;

                foreach (Collider col in obstacles)
                {
                    if (col.gameObject.layer == 6)
                    {
                        curCell.IncreaseCost(255);
                        continue;
                    }
                    else if (!hasIncreasedCost && col.gameObject.layer == 7)
                    {
                        curCell.IncreaseCost(3);
                        hasIncreasedCost = true;
                    }
                }
            }
        }

        public void CreateIntegrationField(Cell _destinationCell)
        {
            destinationCell = _destinationCell;

            destinationCell.Cost = 0;
            destinationCell.BestCost = 0;

            Queue<Cell> cellsToCheck = new Queue<Cell>();

            cellsToCheck.Enqueue(destinationCell);

            while (cellsToCheck.Count > 0)
            {
                Cell curCell = cellsToCheck.Dequeue();
                List<Cell> curNeighbors = GetNeighborCells(curCell.GridIndex, GridDirection.CardinalDirections);
                foreach (Cell curNeighbor in curNeighbors)
                {
                    if (curNeighbor.Cost == byte.MaxValue) { continue; }
                    if (curNeighbor.Cost + curCell.BestCost < curNeighbor.BestCost)
                    {
                        curNeighbor.BestCost = (ushort)(curNeighbor.Cost + curCell.BestCost);
                        cellsToCheck.Enqueue(curNeighbor);
                    }
                }
            }
        }

        //public void CreateFlowField()
        //{
        //    foreach (Cell curCell in grid)
        //    {
        //        List<Cell> curNeighbors = GetNeighborCells(curCell.gridIndex, GridDirection.AllDirections);

        //        int bestCost = curCell.bestCost;

        //        foreach (Cell curNeighbor in curNeighbors)
        //        {
        //            if (curNeighbor.bestCost < bestCost)
        //            {
        //                bestCost = curNeighbor.bestCost;
        //                curCell.bestDirection = GridDirection.GetDirectionFromV2I(curNeighbor.gridIndex - curCell.gridIndex);
        //            }
        //        }
        //    }
        //}

        private List<Cell> GetNeighborCells(Vector2Int nodeIndex, List<GridDirection> directions)
        {
            List<Cell> neighborCells = new List<Cell>();

            foreach (Vector2Int curDirection in directions)
            {
                Cell newNeighbor = GetCellAtRelativePos(nodeIndex, curDirection);
                if (newNeighbor != null)
                {
                    neighborCells.Add(newNeighbor);
                }
            }
            return neighborCells;
        }

        private Cell GetCellAtRelativePos(Vector2Int orignPos, Vector2Int relativePos)
        {
            Vector2Int finalPos = orignPos + relativePos;

            if (finalPos.x < 0 || finalPos.x >= GridSize.x || finalPos.y < 0 || finalPos.y >= GridSize.y)
            {
                return null;
            }

            else { return Grid[finalPos.x, finalPos.y]; }
        }

        public Cell GetCellFromWorldPos(Vector3 worldPos)
        {
            float percentX = worldPos.x / (GridSize.x * _cellDiameter);
            float percentY = worldPos.z / (GridSize.y * _cellDiameter);

            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);

            int x = Mathf.Clamp(Mathf.FloorToInt((GridSize.x) * percentX), 0, GridSize.x - 1);
            int y = Mathf.Clamp(Mathf.FloorToInt((GridSize.y) * percentY), 0, GridSize.y - 1);
            return Grid[x, y];
        }
    }
}

