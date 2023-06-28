using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

// 日本語対応
public class Model : MonoBehaviour
{
    [SerializeField]
    private int _debugMaxHp = 300;
    [SerializeField]
    private int _debugCurrentHp = 100;
    [SerializeField]
    private int _debugMaxSp = 100;
    [SerializeField]
    private int _debugCurrentSp = 50;

    private readonly ReactiveProperty<int> _maxHp = new();
    public int MaxHp { get => _maxHp.Value; set => _maxHp.Value = value; }
    public IObservable<int> MaxHpChanged => _maxHp;

    private readonly ReactiveProperty<int> _currentHp = new();
    public int CurrentHp { get => _currentHp.Value; set => _currentHp.Value = value; }
    public IObservable<int> CurrentHpChanged => _currentHp;

    private readonly ReactiveProperty<int> _maxSp = new();
    public int MaxSp { get => _maxSp.Value; set => _maxSp.Value = value; }
    public IObservable<int> MaxSpChanged => _maxSp;

    private readonly ReactiveProperty<int> _currentSp = new();
    public int CurrentSp { get => _currentSp.Value; set => _currentSp.Value = value; }
    public IObservable<int> CurrentSpChanged => _currentSp;

    private readonly Subject<int> _spEnpty = new();
    public IObservable<int> SpEnpty => _spEnpty;

    private void Start()
    {
        _maxHp.Value = _debugMaxHp;
        _currentHp.Value = _debugCurrentHp;
        _maxSp.Value = _debugMaxSp;
        _currentSp.Value = _debugCurrentSp;
    }

    public void Damage()
    {
        int nextHp = _currentHp.Value;
        nextHp -= UnityEngine.Random.Range(10, 30);

        if (nextHp < 0) nextHp = 0;

        _currentHp.Value = nextHp;
    }

    public void Recovery()
    {
        int nextSp = _currentSp.Value - 5;

        if (nextSp < 0)
        {
            _spEnpty.OnNext(0);
            return;
        }

        _currentSp.Value = nextSp;

        int nextHp = _currentHp.Value;
        nextHp += UnityEngine.Random.Range(10, 30);

        if (nextHp > _maxHp.Value) nextHp = _maxHp.Value;

        _currentHp.Value = nextHp;
    }
}
