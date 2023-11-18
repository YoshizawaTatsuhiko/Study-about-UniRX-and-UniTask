using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
namespace Learning.Singleton
{
    public class InheritanceOfSingletonMonoBehaviour : SingletonMonoBehaviour<InheritanceOfSingletonMonoBehaviour>
    {
        // SingletonMonoBehaviourを継承したクラスでAwake()を使いたいときは、
        // 基底クラスのAwake()を呼んでおく必要がある。
        private void Awake()
        {
            base.Awake();
            DebugText();
        }

        void DebugText()
        {
            Debug.Log("Call");
        }
    }
}
