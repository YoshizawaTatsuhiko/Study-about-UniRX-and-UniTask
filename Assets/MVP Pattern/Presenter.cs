using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

// 日本語対応
public class Presenter : MonoBehaviour
{
    [SerializeField]
    private Button _attackButton = null;
    [SerializeField]
    private Button _recoveryButton = null;
    [SerializeField]
    private ProgressView _hpProgress = null;
    [SerializeField]
    private ProgressView _spProgress = null;
    [SerializeField]
    private MessageDialog _dialog = null;
    [SerializeField]
    private Model _progressModel = null;

    private void Start()
    {
        _attackButton.onClick.AsObservable().Subscribe(_ => _progressModel.Damage());
        _recoveryButton.onClick.AsObservable().Subscribe(_ => _progressModel.Recovery());

        _progressModel.MaxHpChanged.Subscribe(value => _hpProgress.SetMax(value));
        _progressModel.CurrentHpChanged.Subscribe(value => _hpProgress.SetCurrent(value));
        _progressModel.CurrentHpChanged.Skip(1).Subscribe(value => _hpProgress.SetCurrent(value, true));

        _progressModel.MaxSpChanged.Subscribe(value => _spProgress.SetMax(value));
        _progressModel.CurrentSpChanged.Subscribe(value => _spProgress.SetCurrent(value));
        _progressModel.CurrentSpChanged.Skip(1).Subscribe(value => _spProgress.SetCurrent(value, true));
        _progressModel.SpEnpty.Subscribe(_ => _dialog.ShowDialog());
    }
}
