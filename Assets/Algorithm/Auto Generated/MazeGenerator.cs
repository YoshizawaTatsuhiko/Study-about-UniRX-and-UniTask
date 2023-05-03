using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private int _width = 5;
    [SerializeField] private int _height = 5;
    [SerializeField] private SelectAlgorithm _algorithm = SelectAlgorithm.None;
    MazeStrategist _autoAlgorithm = new(new WallExtendAlgorithm());

    private void Start()
    {
        GenerateMaze(_algorithm);
    }

    private void GenerateMaze(SelectAlgorithm algorithm)
    {
        switch (algorithm)
        {
            case SelectAlgorithm.WallExtend:
                _autoAlgorithm.ChangeTheAssembly(new WallExtendAlgorithm());
                break;
            default:
                break;
        }
        string[,] string2DArray = _autoAlgorithm.AssembleFromBlueprint(_width, _height);

        for (int i = 0; i < string2DArray.GetLength(0); i++)
        {
            for (int j = 0; j < string2DArray.GetLength(1); j++)
            {
                string chara = string2DArray[i, j];

                switch (chara)
                {
                    case "W":
                        break;
                    case "F":
                        break;
                }
            }
        }
    }

    private enum SelectAlgorithm
    {
        None,
        WallExtend,
    }
}
