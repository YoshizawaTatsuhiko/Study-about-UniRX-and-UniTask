using UnityEngine;

// 日本語対応
namespace Imitate
{
    public class Recorder : MonoBehaviour
    {
        private void FixedUpdate()
        {
            RecordController.Instance.Recorder.Add(new(transform.position, transform.rotation));
        }
    }
}
