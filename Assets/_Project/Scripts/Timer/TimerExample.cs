using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] TimerView _timerSimpleView;
    [SerializeField] TimerView _timerSliderView;
    [SerializeField] TimerView _timerHeartsView;
    [SerializeField] private KeyCode _resumeButton;
    [SerializeField] private KeyCode _pauseButton;
    [SerializeField] private KeyCode _resetButton;
    [SerializeField, Min(1)] private float _delay;

    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(_delay);
        _timerSimpleView.Initialize(_timer.CurrentTime);
        _timerSliderView.Initialize(_timer.CurrentProgress);
        _timerHeartsView.Initialize(_timer.CurrentTime);
    }

    private void Update()
    {
        _timer.Update(Time.deltaTime);

        if (Input.GetKeyDown(_resumeButton))
            _timer.Resume();
        if (Input.GetKeyDown(_pauseButton))
            _timer.Pause();
        if (Input.GetKeyDown(_resetButton))
            _timer.Reseter();
    }
}
