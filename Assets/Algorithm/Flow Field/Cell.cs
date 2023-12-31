using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class Cell
    {
        public Vector3 _worldPos = Vector3.zero;
        public Vector2Int _gridIndex = Vector2Int.zero;
        //public byte _cost;
        //public ushort _bestCost;
        //public GridDirection _bestDirection;

        public Cell(Vector3 worldPos, Vector2Int gridIndex)
        {
            _worldPos = worldPos;
            _gridIndex = gridIndex;
            //_cost = 1;
        }

        //public void IncreaseCost(byte amount)
        //{
        //    if (_cost == byte.MaxValue) return;

        //    _cost = (byte)Mathf.Min(_cost + amount, byte.MaxValue);
        //}
    }
}
