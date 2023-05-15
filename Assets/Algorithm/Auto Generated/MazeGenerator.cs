using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private int _width = 5;
    [SerializeField] private int _height = 5;
    [SerializeField] private GameObject _wall = null;
    [SerializeField] private GameObject _floor = null;
    [SerializeField] private SelectAlgorithm _algorithm = SelectAlgorithm.None;
    MazeStrategist _autoAlgorithm = null;

    private void Start()
    {
        GenerateMaze(_algorithm);
    }

    private void GenerateMaze(SelectAlgorithm algorithm)
    {
        switch (algorithm)
        {
            case SelectAlgorithm.WallExtend:
                _autoAlgorithm = new(new WallExtendAlgorithm());
                break;
            case SelectAlgorithm.HoleDigging:
                _autoAlgorithm = new(new HoleDiggingAlgorithm());
                break;
            default:
                break;
        }
        string[,] string2DArray = _autoAlgorithm.AssembleFromBlueprint(_width, _height);
        GameObject wallParent = new GameObject("WallParant");
        wallParent.transform.SetParent(transform);
        GameObject floorParent = new GameObject("FloorParant");
        floorParent.transform.SetParent(transform);

        for (int z = 0; z < string2DArray.GetLength(1); z++)
        {
            for (int x = 0; x < string2DArray.GetLength(0); x++)
            {
                string chara = string2DArray[x, z];

                if (chara == "W")
                {
                    Instantiate(_wall, new Vector3
                        (x - _width / 2, transform.position.y, z - _height / 2),
                        Quaternion.identity, wallParent.transform);
                }
                else if (chara == "F")
                {
                    Instantiate(_floor, new Vector3
                        (x - _width / 2, transform.position.y - _wall.transform.localScale.y / 2, z - _height / 2),
                        Quaternion.identity, floorParent.transform);
                }
            }
        }
    }

    private enum SelectAlgorithm
    {
        None,
        WallExtend,
        HoleDigging,
    }
}
