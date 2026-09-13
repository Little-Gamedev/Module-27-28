using System;
using UnityEngine;

public class TimerHolder : MonoBehaviour
{
    public event Action<bool, float> ChangedState
    {
        add => _timer.ChangedState += value;
        remove => _timer.ChangedState -= value;
    }

    public float CurrentTime => _timer.CurrentTime;
    public float CurrentProgress => _timer.CurrentProgress;
    public float CurrentDelay => _timer.CurrentDelay;

    [SerializeField] private float _delay = 10f;

    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(_delay);
    }

    private void Update()
    {
        _timer.Update(Time.deltaTime);
    }

    public void Resume() => _timer.Resume();

    public void Pause() => _timer.Pause();

    public void Reseter() => _timer.Reseter();
}