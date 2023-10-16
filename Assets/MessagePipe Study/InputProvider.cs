using UnityEngine;
using VContainer.Unity;

// 日本語対応
namespace MessagePipe.Sample
{
    public sealed class InputProvider : ITickable
    {
        private readonly IPublisher<InputParam> _inputPublisher = null;

        public InputProvider(IPublisher<InputParam> inputPublisher)
        {
            _inputPublisher = inputPublisher;
        }

        public void Tick()
        {
            var isJump = Input.GetKeyDown(KeyCode.Space);
            var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            var input = new InputParam(isJump, move);
            _inputPublisher.Publish(input);
        }
    }
}