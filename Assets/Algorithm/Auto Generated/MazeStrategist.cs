using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class MazeStrategist
{
    private IMazeStrategy _strategy = null;

    public MazeStrategist(IMazeStrategy strategy)
    {
        _strategy = strategy;
    }

    /// <summary>設計図から迷路を作成する</summary>
    public void AssembleFromBlueprint(int width, int height)
    {
        Debug.Log($"{_strategy?.GetType()}を実行します。");
        string[] strArray = _strategy.CreateBlueprint(width, height).Split("\n");
        string[,] mazeInfo = new string[strArray[0].Length, strArray.Length];
    }

    /// <summary>自動生成アルゴリズムを変更する</summary>
    public void ChangeTheAssembly(IMazeStrategy strategy)
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
