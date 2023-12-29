using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class Cell
    {
        /// <summary>このセルワールド座標</summary>
        public Vector3 WorldPos => _worldPos;
        /// <summary>このセルのグリッド座標</summary>
        public Vector2Int GridPos => _gridPos;

        private Vector3 _worldPos = Vector3.zero;
        private Vector2Int _gridPos = Vector2Int.zero;
        private byte _cost = 0;

        public Cell(Vector3 worldPos, Vector2Int gridPos)
        {
            _worldPos = worldPos;
            _gridPos = gridPos;
            _cost = 1;
        }

        public void IncreaseCost(byte amount)
        {
            if (_cost == byte.MaxValue) return;

            _cost = (byte)Mathf.Min(_cost + amount, byte.MaxValue);
        }
    }
}
