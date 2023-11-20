using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class FlowField
    {
        public FlowFieldCell[,] Grid { get; private set; }
        public Vector2Int GridSize { get; private set; }
        public float CellRadius { get; private set; }

        private float _cellDiameter = 0.0f;

        public FlowField(Vector2Int gridSize, float cellRadius)
        {
            GridSize = gridSize;
            CellRadius = cellRadius;
            _cellDiameter = cellRadius * 2f;
        }

        public void CreateGrid()
        {
            Grid = new FlowFieldCell[GridSize.x, GridSize.y];

            for(int x = 0; x < GridSize.x; x++)
            {
                for(int y = 0; y < GridSize.y; y++)
                {
                    Vector3 worldPos = new Vector3(_cellDiameter * x + CellRadius, _cellDiameter * y + CellRadius);
                    Grid[x, y] = new FlowFieldCell(worldPos, new Vector2Int(x, y));
                }
            }
        }
    }
}

