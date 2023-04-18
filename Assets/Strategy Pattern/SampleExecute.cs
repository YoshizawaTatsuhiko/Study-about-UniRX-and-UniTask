using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class SampleExecute : MonoBehaviour
{
    private StrategyPattern _strategy = new(new Strategy1());

    private void Start()
    {
        _strategy.ExecuteStrategy();
        _strategy.ChangeStrategy(new Strategy2());
        _strategy.ExecuteStrategy();
    }
}
