// 日本語対応
namespace Learning.StrategyPattern
{
    public interface IMazeStrategy
    {
        public abstract string CreateBlueprint(int width, int height);
    }
}