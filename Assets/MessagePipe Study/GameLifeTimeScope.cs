using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

// 日本語対応
namespace Learning.MessagePipe
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private MoveObject _moveObj = null;

        protected override void Configure(IContainerBuilder builder)
        {
            var option = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<InputParam>(option);
            builder.RegisterEntryPoint<InputProvider>(Lifetime.Singleton);
            builder.RegisterBuildCallback(resolver =>
            {
                resolver.Instantiate(_moveObj);
            });
        }
    }
}