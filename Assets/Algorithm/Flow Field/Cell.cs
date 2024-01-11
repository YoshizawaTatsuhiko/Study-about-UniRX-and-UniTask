using UnityEngine;

namespace Learning.Algorithm.FlowField
{
    public class Cell
    {
        public Vector3 WorldPos { get; private set; }
        public Vector2Int GridIndex { get; private set; }
        public byte Cost { get; set; }
        public ushort BestCost { get; set; }
        public GridDirection BestDirection { get; set; }

        public Cell(Vector3 _worldPos, Vector2Int _gridIndex)
        {
            WorldPos = _worldPos;
            GridIndex = _gridIndex;
            Cost = 1;
            BestCost = ushort.MaxValue;
            BestDirection = GridDirection.None;
        }

        public void IncreaseCost(int amnt)
        {
            if (Cost == byte.MaxValue) { return; }
            if (amnt + Cost >= 255) { Cost = byte.MaxValue; }
            else { Cost += (byte)amnt; }
        }
    }
}
