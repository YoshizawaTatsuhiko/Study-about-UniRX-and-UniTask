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

    public void GenerateMaze(int w, int h)
    {
        Debug.Log($"{_strategy?.GetType()}を実行します。");
        _strategy.ExecuteBlueprint(w, h);
    }

    public void ChangeStrategy(IMazeStrategy strategy)
    {
        Debug.Log($"{strategy}に切り替えるまで、3 2 1...");
        _strategy = strategy;
    }
}
