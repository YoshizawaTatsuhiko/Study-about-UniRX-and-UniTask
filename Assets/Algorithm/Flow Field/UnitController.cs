using System.Collections.Generic;
using UnityEngine;

namespace Learning.Algorithm.FlowField
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private GridController _gridController;
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private int _numUnitsPerSpawn;
        [SerializeField] private float _moveSpeed;

        private List<GameObject> _unitsInGame;

        private void Awake()
        {
            _unitsInGame = new List<GameObject>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                SpawnUnits();
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                DestroyUnits();
            }
        }

        private void FixedUpdate()
        {
            if (_gridController.CurFlowField == null) { return; }
            foreach (GameObject unit in _unitsInGame)
            {
                Cell cellBelow = _gridController.CurFlowField.GetCellFromWorldPos(unit.transform.position);
                Vector3 moveDirection = new Vector3(cellBelow.BestDirection.Vector.x, 0, cellBelow.BestDirection.Vector.y);
                Rigidbody unitRB = unit.GetComponent<Rigidbody>();
                unitRB.velocity = moveDirection * _moveSpeed;
            }
        }

        private void SpawnUnits()
        {
            Vector2Int gridSize = _gridController.GridSize;
            float nodeRadius = _gridController.CellRadius;
            Vector2 maxSpawnPos = new Vector2(gridSize.x * nodeRadius * 2 + nodeRadius, gridSize.y * nodeRadius * 2 + nodeRadius);
            int colMask = LayerMask.GetMask("Impassible", "Units");
            Vector3 newPos;
            for (int i = 0; i < _numUnitsPerSpawn; i++)
            {
                GameObject newUnit = Instantiate(_unitPrefab);
                newUnit.transform.parent = transform;
                _unitsInGame.Add(newUnit);
                do
                {
                    newPos = new Vector3(Random.Range(0, maxSpawnPos.x), 0, Random.Range(0, maxSpawnPos.y));
                    newUnit.transform.position = newPos;
                }
                while (Physics.OverlapSphere(newPos, 0.25f, colMask).Length > 0);
            }
        }

        private void DestroyUnits()
        {
            foreach (GameObject go in _unitsInGame)
            {
                Destroy(go);
            }
            _unitsInGame.Clear();
        }
    }
}
