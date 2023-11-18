using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

// 日本語対応
namespace Learning.MessagePipe
{
    [RequireComponent(typeof(CharacterController))]
    public class MoveObject : MonoBehaviour
    {
        [Inject] ISubscriber<InputParam> _inputSubscriber = null;
        [SerializeField] private readonly float _jumpPower = 1.0f;
        [SerializeField] private readonly float _moveSpeed = 1.0f;

        private CharacterController _controller = null;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _inputSubscriber.Subscribe(OnInputReceiver).AddTo(this.GetCancellationTokenOnDestroy());
        }

        private void OnInputReceiver(InputParam input)
        {
            Vector3 moveVelocity = new Vector3(0f, _controller.velocity.y, 0f);

            if (input.CanJump && _controller.isGrounded)
            {
                moveVelocity += Vector3.up * _jumpPower;
            }
            moveVelocity += input.Move * _moveSpeed;
            moveVelocity += Physics.gravity * Time.deltaTime;
            _controller.Move(moveVelocity * Time.deltaTime);
        }
    }
}