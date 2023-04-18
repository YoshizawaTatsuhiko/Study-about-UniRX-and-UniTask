using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class StrategyPattern : MonoBehaviour
{
    private IStrategy _strategy = null;

    public StrategyPattern(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        Debug.Log("登録されているStrategyを実行します。");
        _strategy.Strategy();
    }

    public void ChangeStrategy(IStrategy strategy)
    {
        Debug.Log("登録されているStrategyを変更します。");
        _strategy = strategy;
    }
}
