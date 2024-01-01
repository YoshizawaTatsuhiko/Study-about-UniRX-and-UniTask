using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class GridController : MonoBehaviour
    {
        public Vector2Int GridSize => _gridSize;
        public float CellRadius => _cellRadius;

        [SerializeField] private Vector2Int _gridSize = Vector2Int.zero;
        [SerializeField] private float _cellRadius = 0.5f;
        [SerializeField] private GridDebug gridDebug = null;

        private FlowField _curFlowField = null;

        private void InitializeFlowField()
        {
            _curFlowField = new FlowField(_cellRadius, _gridSize);
            _curFlowField.CreateGrid();
            gridDebug.SetFlowField(_curFlowField);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) // LeftClick
            {
                InitializeFlowField();

                _curFlowField.CreateCostField();

                //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
                //Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
                //Cell destinationCell = curFlowField.GetCellFromWorldPos(worldMousePos);
                //curFlowField.CreateIntegrationField(destinationCell);

                //_curFlowField.CreateFlowField();

                //gridDebug.DrawFlowField();
            }
        }
    }
}
