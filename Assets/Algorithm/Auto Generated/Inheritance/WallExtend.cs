using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExtend : Blueprint
{
    /// <summary>壁生成開始地点</summary>
    List<(int, int)> _startPoint = new List<(int, int)>();
    /// <summary>拡張中の壁の情報を格納する</summary>
    Stack<(int, int)> _currentWall = new Stack<(int, int)>();

    /// <summary>迷路を生成する</summary>
    public override string[,] AssembleMaze(int width, int height)
    {
        // 迷路の大きさが5未満だったら、エラーを出力する。
        if (width < 5 || height < 5) Debug.LogError("ArgumentOutOfRangeException");
        // 縦(横)の長さが偶数だったら、奇数に変換する。
        width = width % 2 == 0 ? ++width : width;
        height = height % 2 == 0 ? ++height : height;
        
        // 迷路の情報を格納する。
        string[,] maze = new string[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // 外周を壁で囲む。
                if (x * y == 0 || x == width - 1 || y == height - 1)
                {
                    maze[x, y] = "W";
                }
                // 外周以外は床で埋める。
                else
                {
                    maze[x, y] = "F";
                    // x, y共に偶数の座標をリストに追加する。
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        _startPoint.Add((x, y));
                    }
                }
            }
        }
        ExtendWall(maze, _startPoint);

        return maze;
    }

    /// <summary>壁を拡張する</summary>
    private void ExtendWall(string[,] maze, List<(int, int)> startPoint)
    {
        int index = Random.Range(0, startPoint.Count);
        int x = startPoint[index].Item1;
        int y = startPoint[index].Item2;
        startPoint.RemoveAt(index);
        bool isFloor = true;

        while (isFloor)
        {
            // 拡張できる方向を格納するリスト
            List<string> dirs = new List<string>();

            if (maze[x, y - 1] == "F" && !IsCurrentWall(x, y - 2)) dirs.Add("Up");
            if (maze[x, y + 1] == "F" && !IsCurrentWall(x, y + 2)) dirs.Add("Down");
            if (maze[x - 1, y] == "F" && !IsCurrentWall(x - 2, y)) dirs.Add("Left");
            if (maze[x + 1, y] == "F" && !IsCurrentWall(x + 2, y)) dirs.Add("Right");
            // 拡張する方向が見つからなかったら、ループを抜ける
            if (dirs.Count == 0) break;
            // 壁を設置する
            SetWall(maze, x, y);
            int dirsIndex = Random.Range(0, dirs.Count);
            try
            {
                switch (dirs[dirsIndex])
                {
                    case "Up":
                        isFloor = maze[x, y - 2] == "F";
                        SetWall(maze, x, --y);
                        SetWall(maze, x, --y);
                        break;
                    case "Down":
                        isFloor = maze[x, y + 2] == "F";
                        SetWall(maze, x, ++y);
                        SetWall(maze, x, ++y);
                        break;
                    case "Left":
                        isFloor = maze[x - 2, y] == "F";
                        SetWall(maze, --x, y);
                        SetWall(maze, --x, y);
                        break;
                    case "Right":
                        isFloor = maze[x + 2, y] == "F";
                        SetWall(maze, ++x, y);
                        SetWall(maze, ++x, y);
                        break;
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        // 拡張できるポイントがまだあったら拡張を続ける。
        if (startPoint.Count > 0)
        {
            _currentWall.Clear();
            ExtendWall(maze, startPoint);
        }
    }

    /// <summary>壁を設置する</summary>
    private void SetWall(string[,] maze, int x, int y)
    {
        maze[x, y] = "W";
        // x, yが共に偶数だったら、リストから削除し、スタックに格納する。
        if (x % 2 == 0 && y % 2 == 0)
        {
            _startPoint.Remove((x, y));
            _currentWall.Push((x, y));
        }
    }

    /// <summary>拡張中の壁かどうか判定する</summary>
    /// <returns>true -> 拡張中 | false -> 拡張済</returns>
    private bool IsCurrentWall(int x, int y)
    {
        return _currentWall.Contains((x, y));
    }
}
