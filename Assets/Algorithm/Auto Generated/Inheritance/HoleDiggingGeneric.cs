using System;
using System.Collections.Generic;

// 日本語対応
public class HoleDiggingGeneric : Blueprint
{
    private List<(int, int)> _startList = new List<(int, int)>();
    private Random _random = new();

    public override T[,] GenericAssembleMaze<T>(int width, int height, T wall, T path)
    {
        // 迷路の大きさが5未満だったら、エラーを出力する。
        if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException();
        // 縦(横)の長さが偶数だったら、奇数に変換する。
        width = width % 2 == 0 ? ++width : width;
        height = height % 2 == 0 ? ++height : height;

        // 迷路の情報を格納する。
        T[,] maze = new T[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // 迷路の外周を床で埋めておく。
                if (x * y == 0 || x == width - 1 || y == height - 1)
                {
                    maze[x, y] = path;
                }
                // それ以外を壁で埋める。
                else
                {
                    maze[x, y] = wall;
                }
            }
        }







        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x * y == 0 || x == width - 1 || y == height - 1)
                {
                    maze[x, y] = wall;
                }
            }
        }
        return maze;
    }

    private void DiggingPath(string[,] maze, (int, int) coodinate)
    {
        if (_startList.Count > 0) _startList.Remove(coodinate);

        int x = coodinate.Item1;
        int y = coodinate.Item2;

        while (true)
        {
            // 拡張できる方向を格納するリスト
            List<string> dirs = new List<string>();

            if (maze[x, y - 1] == "W" && maze[x, y - 2] == "W") dirs.Add("Up");
            if (maze[x, y + 1] == "W" && maze[x, y + 2] == "W") dirs.Add("Down");
            if (maze[x - 1, y] == "W" && maze[x - 2, y] == "W") dirs.Add("Left");
            if (maze[x + 1, y] == "W" && maze[x + 2, y] == "W") dirs.Add("Right");
            // 拡張できる方向がなくなったら、ループを抜ける。
            if (dirs.Count == 0) break;
            // 通路を設置する
            SetPath(maze, x, y);
            int dirsIndex = _random.Next(0, dirs.Count);

            try
            {
                switch (dirs[dirsIndex])
                {
                    case "Up":
                        SetPath(maze, x, --y);
                        SetPath(maze, x, --y);
                        break;
                    case "Down":
                        SetPath(maze, x, ++y);
                        SetPath(maze, x, ++y);
                        break;
                    case "Left":
                        SetPath(maze, --x, y);
                        SetPath(maze, --x, y);
                        break;
                    case "Right":
                        SetPath(maze, ++x, y);
                        SetPath(maze, ++x, y);
                        break;
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        if (_startList.Count > 0)
        {
            int random = _random.Next(0, _startList.Count);
            DiggingPath(maze, _startList[random]);
        }
    }

    private void SetPath(string[,] maze, int x, int y)
    {
        maze[x, y] = "F";
        // x, yが共に奇数だったら、リストから削除する。
        if (x % 2 != 0 && y % 2 != 0)
        {
            _startList.Add((x, y));
        }
    }
}
