using UnityEngine;

// 日本語対応
namespace Learning.StrategyPattern
{
    public class Strategy1 : IStrategy
    {
        public void Strategy()
        {
            Debug.Log("俺の名前は「ありがとう」だ");
        }
    }
}
