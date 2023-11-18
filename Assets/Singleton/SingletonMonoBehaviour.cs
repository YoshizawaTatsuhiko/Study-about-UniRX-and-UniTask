using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
namespace Learning.Singleton
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (!instance)
                    {
                        Debug.LogError($"{typeof(T)} is nothing");
                    }
                }
                return instance;
            }
        }

        protected void Awake()
        {
            CheckInstance();
        }

        /// <summary>自身のInstanceがすでに確保されているかどうかの判定をする</summary>
        private void CheckInstance()
        {
            if (Instance == this) return;
            else Destroy(this);
        }
    }
}
