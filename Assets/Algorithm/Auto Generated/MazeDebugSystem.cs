using UnityEngine;
using UnityEngine.SceneManagement;

// 日本語対応
namespace Learning.Algorithm
{
    public class MazeDebugSystem : MonoBehaviour
    {
        [SerializeField] private KeyCode _keycode = KeyCode.None;

        private void Update()
        {
            if (Input.GetKeyDown(_keycode))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
