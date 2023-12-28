using UnityEngine;

// 日本語対応
namespace Imitate
{
    public class RecordViewer : MonoBehaviour
    {
        private int _traceIndex = -1;

        private void FixedUpdate()
        {
            int n = Mathf.Min(++_traceIndex, RecordController.Instance.Recorder.Count - 1);
            var data = RecordController.Instance.Recorder[n];
            transform.position = data.Position;
            transform.rotation = data.Rotation;
        }
    }
}
