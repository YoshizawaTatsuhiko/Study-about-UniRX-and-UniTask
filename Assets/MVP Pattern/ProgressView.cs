using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// 日本語対応
public class ProgressView : MonoBehaviour
{
    [SerializeField]
    private Text _currentValueText = null;
    [SerializeField]
    private Text _maxValueText = null;
    [SerializeField]
    private Slider _gaugeSlider = null;
    private Tween _tween = null;

    public void SetMax(float value)
    {
        _gaugeSlider.maxValue = value;
        _maxValueText.text = _gaugeSlider.maxValue.ToString();
    }

    public void SetCurrent(float newValue, bool useAnimation = false)
    {
        bool isPlus = _gaugeSlider.value > newValue;

        _gaugeSlider.value = newValue;
        _tween.Kill();

        if (!useAnimation || isPlus)
        {
            _currentValueText.text = newValue.ToString();
        }
        else
        {
            _tween = DOTween.To(() => _gaugeSlider.value,
                value => _gaugeSlider.value = value, newValue, 0.35f);
        }
    }
}
