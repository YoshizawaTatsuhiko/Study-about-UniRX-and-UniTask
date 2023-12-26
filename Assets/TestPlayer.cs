using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TestPlayer : MonoBehaviour
{
    [SerializeField] private PlayerInput _input = new PlayerInput();
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _jumpPower = 10.0f;
    [SerializeField] private float _gravity = 9.81f;

    private CharacterController _charaCtrl = null;
    private Vector3 _moveDirection = Vector3.zero;

    private void Start()
    {
        _charaCtrl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        if (_charaCtrl.isGrounded)
        {
            _moveDirection = new Vector3(_input.Horizontal, 0.0f, _input.Vertical).normalized * _moveSpeed;
            _moveDirection.y = _input.Jump * _jumpPower;
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
        _charaCtrl.Move(_moveDirection * Time.deltaTime);
    }

    private void Look()
    {
        Vector3 look = new(_moveDirection.x, 0.0f, _moveDirection.z);
        if (look == Vector3.zero) return;
        transform.rotation = Quaternion.LookRotation(look);
    }
}
