using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// 日本語対応
public class MessageDialog : MonoBehaviour
{
    private CanvasGroup _canvasGroup = null;
    private Tween _tween = null;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        gameObject.SetActive(false);
    }

    public void ShowDialog()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1f;
        _tween.Kill();

        DOVirtual.
            DelayedCall(1f, () => _canvasGroup.DOFade(0f, 1f)).
            OnComplete(() => gameObject.SetActive(false));
    }
}
