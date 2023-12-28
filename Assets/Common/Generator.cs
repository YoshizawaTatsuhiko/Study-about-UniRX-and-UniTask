using UnityEngine;

// 日本語対応
public class Generator : MonoBehaviour
{
    [SerializeField] private float _interval = 1.0f;
    [SerializeField] private GameObject _initObj = null;
    [SerializeField] private GameObject _obj = null;

    private float _timer = 0.0f;

    private void Start()
    {
        if (_obj == null) throw new System.NullReferenceException();
        if(_initObj != null) Instantiate(_initObj, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            _timer = 0.0f;
            Instantiate(_obj, transform.position, Quaternion.identity, transform);
        }
    }
}
