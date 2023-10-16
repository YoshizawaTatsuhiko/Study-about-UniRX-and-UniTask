using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
namespace MessagePipe.Sample
{
    public struct InputParam
    {
        public bool IsJump { get; }
        public Vector3 Move { get; }

        public InputParam(bool isJump, Vector3 move)
        {
            IsJump = isJump;
            Move = move;
        }
    }
}
