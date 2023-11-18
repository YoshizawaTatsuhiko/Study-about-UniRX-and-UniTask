using UnityEngine;

// 日本語対応
namespace Learning.StrategyPattern
{
    public class Strategy2 : IStrategy
    {
        public void Strategy()
        {
            Debug.Log("私の名前は「ごめんなさい」です");
        }
    }
}
