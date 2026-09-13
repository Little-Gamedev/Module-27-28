using System;

public class Timer
{
    public event Action<bool, float> ChangedState;

    public float CurrentTime => _time;
    public float CurrentProgress => _time / _delay;
    public float CurrentDelay => _delay;

    private float _time = 0;
    private float _delay;

    private bool _isStart;

    public Timer(float delay)
    {
        _delay = delay;
    }

    public void Resume()
    {
        _isStart = true;
        ChangedState?.Invoke(_isStart, _time);
    }

    public void Pause()
    {
        _isStart = false;
        ChangedState?.Invoke(_isStart, _time);
    }

    public void Reseter()
    {
        _isStart = false;
        _time = 0;
        ChangedState?.Invoke(_isStart, _time);
    }

    public void Update(float deltaTime)
    {
        if (_isStart == false)
            return;

        _time += deltaTime;

        ChangedState?.Invoke(_isStart, _time);

        if (_time >= _delay)
            Reseter();
    }
}
