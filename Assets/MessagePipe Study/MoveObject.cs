using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;

// 日本語対応
namespace MessagePipe.Sample
{
    public class MoveObject : MonoBehaviour
    {
        [Inject] ISubscriber<InputParam> _inputSUbscriber = null;
    }
}