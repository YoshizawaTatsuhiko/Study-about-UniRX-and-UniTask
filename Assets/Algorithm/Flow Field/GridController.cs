using UnityEngine;

namespace Learning.Algorithm.FlowField
{
    public class GridController : MonoBehaviour
    {
        public Vector2Int GridSize => _gridSize;
        public float CellRadius => _cellRadius;
        public FlowField CurFlowField { get; private set; }

        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private float _cellRadius = 0.5f;
        [SerializeField] private GridDebug _gridDebug;

        private void InitializeFlowField()
        {
            CurFlowField = new FlowField(CellRadius, GridSize);
            CurFlowField.CreateGrid();
            _gridDebug.SetFlowField(CurFlowField);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InitializeFlowField();

                CurFlowField.CreateCostField();

                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Cell destinationCell = CurFlowField.GetCellFromWorldPos(worldMousePos);
                CurFlowField.CreateIntegrationField(destinationCell);

                CurFlowField.CreateFlowField();

                _gridDebug.DrawFlowField();
            }
        }
    }
}
