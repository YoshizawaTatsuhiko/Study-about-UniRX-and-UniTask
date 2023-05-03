using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class MazeStrategist
{
    private IMazeAlgorithm _strategy = null;

    public MazeStrategist(IMazeAlgorithm strategy)
    {
        _strategy = strategy;
    }

    /// <summary>設計図から迷路を作成する</summary>
    public string[,] AssembleFromBlueprint(int width, int height)
    {
        Debug.Log($"{_strategy?.GetType()}を実行します。");
        string[] strArray = _strategy.CreateBlueprint(width, height).Split("\n");
        string[,] mazeInfo = To2DArray(strArray);
        return mazeInfo;
    }

    /// <summary>アルゴリズムを変更する</summary>
    public void ChangeTheAssembly(IMazeAlgorithm strategy)
    {
        Debug.Log($"{_strategy} => {strategy}に切り替えるまで、3 2 1...");
        _strategy = strategy;
    }

    private string[,] To2DArray(string[] array)
    {
        string[,] twoDimensionalArray = new string[array[0].Length, array.Length];

        for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
        {
            for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
            {
                twoDimensionalArray[i, j] = array[i][j].ToString();
            }
        }
        return twoDimensionalArray;
    }
}
