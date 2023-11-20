using Learning.Algorithm.FlowField;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class GridController : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize = Vector2Int.zero;
    [SerializeField] private float _cellRadius = 0.5f;

    private FlowField _currentFlowField = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InitFlowField();
        }
    }

    private void InitFlowField()
    {
        _currentFlowField = new FlowField(_gridSize, _cellRadius);
        _currentFlowField.CreateGrid();
    }
}
