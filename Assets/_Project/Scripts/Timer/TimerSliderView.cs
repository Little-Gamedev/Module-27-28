using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : TimerView
{
    [SerializeField] private Slider _slider;

    protected override void Show(float value) => _slider.value = value;
}
