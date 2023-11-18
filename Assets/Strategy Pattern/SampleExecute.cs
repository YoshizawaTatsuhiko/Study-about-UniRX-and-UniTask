using UnityEngine;

// 日本語対応
namespace Learning.StrategyPattern
{
    public class SampleExecute : MonoBehaviour
    {
        private Strategy _strategy = new(new Strategy1());

        private void Start()
        {
            _strategy.ExecuteStrategy();
            _strategy.ChangeStrategy(new Strategy2());
            _strategy.ExecuteStrategy();
        }
    }
}
