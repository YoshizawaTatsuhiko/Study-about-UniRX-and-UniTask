using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class Cell
    {
        public Vector3 WorldPos => _worldPos;
        public Vector2Int GridIndex => _gridIndex;
        public byte Cost { get => _cost; set => _cost = value; }
        public ushort BestCost { get => _bestCost; set => _bestCost = value; }

        private Vector3 _worldPos = Vector3.zero;
        private Vector2Int _gridIndex = Vector2Int.zero;
        private byte _cost = 0;
        private ushort _bestCost = 0;
        private GridDirection _bestDirection = GridDirection.None;

        public Cell(Vector3 worldPos, Vector2Int gridIndex)
        {
            _worldPos = worldPos;
            _gridIndex = gridIndex;
            _cost = 1;
            _bestCost = ushort.MaxValue;
        }

        public void IncreaseCost(int amount)
        {
            if (_cost == byte.MaxValue) return;

            _cost = (byte)Mathf.Min(_cost + amount, byte.MaxValue);
        }
    }
}
