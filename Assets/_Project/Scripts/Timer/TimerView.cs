using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countTimerTMP;
    [SerializeField] private TimerHolder _timerHolder;

    private void Start()
    {
        _timerHolder.ChangedState += UpdateCount;
        _countTimerTMP.text = ((int)_timerHolder.CurrentTime).ToString();
    }

    private void OnDestroy()
    {
        _timerHolder.ChangedState -= UpdateCount;
    }

    private void UpdateCount(bool active, float time) => _countTimerTMP.text = ((int)time).ToString();
}
