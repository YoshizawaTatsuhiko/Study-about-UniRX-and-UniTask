using System;
using System.Collections.Generic;

// 日本語対応
public class HoleDiggingGeneric : Blueprint
{
    /// <summary>通路拡張開始地点候補</summary>
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
        DiggingPath(maze, (1, 1), wall, path);

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

    private void DiggingPath<T>(T[,] maze, (int, int) coodinate, T wall, T path)
    {
        if (_startList.Count > 0) _startList.Remove(coodinate);

        int x = coodinate.Item1;
        int y = coodinate.Item2;

        while (true)
        {
            // 拡張できる方向を格納するリスト
            List<Direction> dirs = new();

            //if (maze[x, y - 1] == wall && maze[x, y - 2] == wall) dirs.Add(Direction.UP);
            //if (maze[x, y + 1] == wall && maze[x, y + 2] == wall) dirs.Add(Direction.DOWN);
            //if (maze[x - 1, y] == wall && maze[x - 2, y] == wall) dirs.Add(Direction.LEFT);
            //if (maze[x + 1, y] == wall && maze[x + 2, y] == wall) dirs.Add(Direction.RIGHT);

            // 拡張できる方向がなくなったら、ループを抜ける。
            if (dirs.Count == 0) break;
            // 通路を設置する
            SetPath(maze, x, y, path);
            int dirsIndex = _random.Next(0, dirs.Count);

            try
            {
                switch (dirs[dirsIndex])
                {
                    case Direction.UP:
                        SetPath(maze, x, --y, path);
                        SetPath(maze, x, --y, path);
                        break;
                    case Direction.DOWN:
                        SetPath(maze, x, ++y, path);
                        SetPath(maze, x, ++y, path);
                        break;
                    case Direction.LEFT:
                        SetPath(maze, --x, y, path);
                        SetPath(maze, --x, y, path);
                        break;
                    case Direction.RIGHT:
                        SetPath(maze, ++x, y, path);
                        SetPath(maze, ++x, y, path);
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        if (_startList.Count > 0)
        {
            int random = _random.Next(0, _startList.Count);
            DiggingPath(maze, _startList[random], wall, path);
        }
    }

    private void SetPath<T>(T[,] maze, int x, int y, T path)
    {
        maze[x, y] = path;
        // x, yが共に奇数だったら、リストから削除する。
        if (x % 2 != 0 && y % 2 != 0)
        {
            _startList.Add((x, y));
        }
    }

    private enum Direction : byte
    {
        UP      = 0,
        DOWN    = 1,
        LEFT    = 2,
        RIGHT   = 4,
    }
}
