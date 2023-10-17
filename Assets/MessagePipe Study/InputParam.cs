using UnityEngine;

// 日本語対応
namespace MessagePipe.Sample
{
    /// <summary>入力の情報を受け付ける</summary>
    public struct InputParam
    {
        public bool CanJump { get; }
        public Vector3 Move { get; }

        public InputParam(bool canJump, Vector3 move)
        {
            CanJump = canJump;
            Move = move;
        }
    }
}
