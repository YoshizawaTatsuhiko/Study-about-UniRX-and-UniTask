using UnityEngine;

// 日本語対応
namespace Learning.StrategyPattern
{
    public class Strategy : MonoBehaviour
    {
        private IStrategy _strategy = null;

        public Strategy(IStrategy strategy)
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
}
