using UnityEngine;

// 日本語対応
[System.Serializable]
public class PlayerInput
{
    public float Horizontal
    {
        get
        {
            float lr = 0.0f;
            if (Input.GetKey(_left)) lr += -1.0f;
            if (Input.GetKey(_right)) lr += 1.0f;
            return lr;
        }
    }
    public float Vertical
    {
        get
        {
            float ud = 0.0f;
            if (Input.GetKey(_up)) ud += 1.0f;
            if (Input.GetKey(_down)) ud += -1.0f;
            return ud;
        }
    }
    public float Jump => Input.GetKeyDown(_jump) ? 1.0f : 0.0f;

    [SerializeField] private KeyCode _up = KeyCode.W;
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _down = KeyCode.S;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
}
