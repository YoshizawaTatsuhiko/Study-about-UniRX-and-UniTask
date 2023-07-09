using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// 日本語対応
public class Blueprint
{
    public virtual string[,] AssembleMaze(int width, int height)
    {
        return null;
    }

    public virtual T[,] GenericAssembleMaze<T>(int width, int height, T wall, T path)
    {
        return null;
    }

    /// <summary>迷路を文字列にして表示する</summary>
    /// <param name="maze">迷路</param>
    /// <returns>文字列化した迷路</returns>
    protected string ArrayToString(string[,] maze)
    {
        string str = "";

        for (int i = 0; i < maze.GetLength(1); i++)
        {
            for (int j = 0; j < maze.GetLength(0); j++)
            {
                str += maze[i, j];
            }
            if (i < maze.Length - 1) str += "\n";
        }
        Debug.Log(str);
        return str;
    }
}
