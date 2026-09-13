using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TimerHolder _timerHolder;

    private void Start() => _timerHolder.ChangedState += UpdateProgress;

    private void OnDestroy() => _timerHolder.ChangedState -= UpdateProgress;

    private void UpdateProgress(bool active, float time)
    {
        _slider.value = _timerHolder.CurrentProgress;
    }
}
