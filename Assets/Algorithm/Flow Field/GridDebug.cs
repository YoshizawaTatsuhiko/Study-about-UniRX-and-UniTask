using UnityEditor;
using UnityEngine;

// 日本語対応
namespace Learning.Algorithm.FlowField
{
    public class GridDebug : MonoBehaviour
    {
        [SerializeField] private GridController gridController;
        [SerializeField] private bool displayGrid;

        [SerializeField] private FlowFieldDisplayType curDisplayType;

        private Vector2Int gridSize;
        private float cellRadius;
        private FlowField curFlowField;

        private Sprite[] ffIcons;

        //private void Start()
        //{
        //    ffIcons = Resources.LoadAll<Sprite>("Sprites/FFicons");
        //}

        public void SetFlowField(FlowField newFlowField)
        {
            curFlowField = newFlowField;
            cellRadius = newFlowField.CellRadius;
            gridSize = newFlowField.GridSize;
        }

        //public void DrawFlowField()
        //{
        //    ClearCellDisplay();

        //    switch (curDisplayType)
        //    {
        //        case FlowFieldDisplayType.AllIcons:
        //            DisplayAllCells();
        //            break;

        //        case FlowFieldDisplayType.DestinationIcon:
        //            DisplayDestinationCell();
        //            break;

        //        default:
        //            break;
        //    }
        //}

        //private void DisplayAllCells()
        //{
        //    if (curFlowField == null) { return; }
        //    foreach (Cell curCell in curFlowField.grid)
        //    {
        //        DisplayCell(curCell);
        //    }
        //}

        //private void DisplayDestinationCell()
        //{
        //    if (curFlowField == null) { return; }
        //    DisplayCell(curFlowField.destinationCell);
        //}

        //private void DisplayCell(Cell cell)
        //{
        //    GameObject iconGO = new GameObject();
        //    SpriteRenderer iconSR = iconGO.AddComponent<SpriteRenderer>();
        //    iconGO.transform.parent = transform;
        //    iconGO.transform.position = cell.worldPos;

        //    if (cell.cost == 0)
        //    {
        //        iconSR.sprite = ffIcons[3];
        //        Quaternion newRot = Quaternion.Euler(90, 0, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.cost == byte.MaxValue)
        //    {
        //        iconSR.sprite = ffIcons[2];
        //        Quaternion newRot = Quaternion.Euler(90, 0, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.North)
        //    {
        //        iconSR.sprite = ffIcons[0];
        //        Quaternion newRot = Quaternion.Euler(90, 0, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.South)
        //    {
        //        iconSR.sprite = ffIcons[0];
        //        Quaternion newRot = Quaternion.Euler(90, 180, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.East)
        //    {
        //        iconSR.sprite = ffIcons[0];
        //        Quaternion newRot = Quaternion.Euler(90, 90, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.West)
        //    {
        //        iconSR.sprite = ffIcons[0];
        //        Quaternion newRot = Quaternion.Euler(90, 270, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.NorthEast)
        //    {
        //        iconSR.sprite = ffIcons[1];
        //        Quaternion newRot = Quaternion.Euler(90, 0, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.NorthWest)
        //    {
        //        iconSR.sprite = ffIcons[1];
        //        Quaternion newRot = Quaternion.Euler(90, 270, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.SouthEast)
        //    {
        //        iconSR.sprite = ffIcons[1];
        //        Quaternion newRot = Quaternion.Euler(90, 90, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else if (cell.bestDirection == GridDirection.SouthWest)
        //    {
        //        iconSR.sprite = ffIcons[1];
        //        Quaternion newRot = Quaternion.Euler(90, 180, 0);
        //        iconGO.transform.rotation = newRot;
        //    }
        //    else
        //    {
        //        iconSR.sprite = ffIcons[0];
        //    }
        //}

        //public void ClearCellDisplay()
        //{
        //    foreach (Transform t in transform)
        //    {
        //        GameObject.Destroy(t.gameObject);
        //    }
        //}

        private void OnDrawGizmos()
        {
            if (displayGrid)
            {
                if (curFlowField == null)
                {
                    DrawGrid(gridController.GridSize, Color.white, gridController.CellRadius);
                }
                else
                {
                    DrawGrid(gridSize, Color.red, cellRadius);
                }
            }

            if (curFlowField == null) { return; }

            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.alignment = TextAnchor.MiddleCenter;

            switch (curDisplayType)
            {
                case FlowFieldDisplayType.CostField:

                    foreach (Cell curCell in curFlowField.Grid)
                    {
                        Handles.Label(curCell.WorldPos, curCell.Cost.ToString(), style);
                    }
                    break;

                //case FlowFieldDisplayType.IntegrationField:

                //    foreach (Cell curCell in curFlowField.grid)
                //    {
                //        Handles.Label(curCell.worldPos, curCell.bestCost.ToString(), style);
                //    }
                //    break;

                default:
                    break;
            }
        }

        private void DrawGrid(Vector2Int drawGridSize, Color drawColor, float drawCellRadius)
        {
            Gizmos.color = drawColor;

            for (int y = 0; y < drawGridSize.y; y++)
            {
                for (int x = 0; x < drawGridSize.x; x++)
                {
                    Vector3 center = new Vector3(
                        drawCellRadius * 2f * x + drawCellRadius, 0f, drawCellRadius * 2f * -y - drawCellRadius);
                    center += new Vector3(drawGridSize.x / -2f, 0f, drawGridSize.y / 2f);
                    Vector3 size = Vector3.one * drawCellRadius * 2f;
                    Gizmos.DrawWireCube(center, size);
                }
            }
        }
    }

    public enum FlowFieldDisplayType
    {
        None,
        AllIcon,
        DestinationIcon,
        CostField,
        IntField,
    }
}
