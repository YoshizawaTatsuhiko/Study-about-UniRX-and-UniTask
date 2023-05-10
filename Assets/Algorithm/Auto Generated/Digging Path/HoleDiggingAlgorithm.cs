using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// 日本語対応
public class HoleDiggingAlgorithm : Blueprint, IMazeStrategy
{
    /// <summary>通路拡張開始地点</summary>
    List<(int, int)> _startList = new List<(int, int)> ();
    /// <summary>拡張中の通路の情報を格納する</summary>
    Stack<(int, int)> _currentPath = new Stack<(int, int)> ();

    public string CreateBlueprint(int width, int height)
    {
        // 迷路の大きさが5未満だったら、エラーを出力する。
        if( width <= 0 || height <= 0 ) throw new System.ArgumentOutOfRangeException();
        // 縦(横)の長さが偶数だったら、奇数に変換する。
        width = width % 2 == 0 ? ++width : width;
        height = height % 2 == 0 ? ++height : height;

        // 迷路の情報を格納する。
        string[,] maze = new string[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // 迷路の外周を床で埋めておく。
                if (x * y == 0 || x == width - 1 || y == height - 1)
                {
                    maze[x, y] = "F";
                }
                // それ以外を壁で埋める。
                else
                {
                    maze[x, y] = "W";
                    // x, y共に奇数の座標をリストに追加する。
                    if (x % 2 != 0 && y % 2 != 0)
                    {
                        _startList.Add((x, y));
                    }
                }
            }
        }



        return ArrayToString(maze);
    }

    /// <summary>通路を掘る</summary>
    private void DiggingPath(string[,] maze, List<(int, int)> list)
    {
        int index = Random.Range(0, list.Count);
        int x = list[index].Item1;
        int y = list[index].Item2;
        list.Remove(list[index]);


    }
}
