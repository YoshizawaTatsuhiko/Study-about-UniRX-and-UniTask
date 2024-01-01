using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class Cell
    {
        public Vector3 WorldPos => _worldPos;
        public Vector2Int GridIndex => _gridIndex;
        public byte Cost => _cost;
        //public ushort _bestCost;
        //public GridDirection _bestDirection;

        private Vector3 _worldPos = Vector3.zero;
        private Vector2Int _gridIndex = Vector2Int.zero;
        private byte _cost = 0;

        public Cell(Vector3 worldPos, Vector2Int gridIndex)
        {
            _worldPos = worldPos;
            _gridIndex = gridIndex;
            _cost = 1;
        }

        public void IncreaseCost(int amount)
        {
            if (_cost == byte.MaxValue) return;

            _cost = (byte)Mathf.Min(_cost + amount, byte.MaxValue);
        }
    }
}
