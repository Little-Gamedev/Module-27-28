using System;

public class Timer
{
    public event Action Finished;

    private readonly ReactiveVariable<float> _time;

    private readonly ReactiveVariable<bool> _isRunning;
    private readonly ReactiveVariable<float> _progress;
    private readonly float _delay;

    public IReadOnlyVariable<float> CurrentTime => _time;
    public IReadOnlyVariable<bool> IsRunning => _isRunning;

    public IReadOnlyVariable<float> CurrentProgress => _progress;
    public float CurrentDelay => _delay;

    public Timer(float delay)
    {
        _time = new ReactiveVariable<float>();
        _progress = new ReactiveVariable<float>();
        _isRunning = new ReactiveVariable<bool>();

        if (delay <= 0)
        {
            UnityEngine.Debug.LogError("[Timer] Максимальное время таймера не может быть 0 или отрицательным. Выставлено значение = 1");
            _delay = 1;
        }
        else
        {
            _delay = delay;
        }
    }

    public void Resume() => _isRunning.Value = true;
    public void Pause() => _isRunning.Value = false;

    public void Reseter()
    {
        _isRunning.Value = false;
        _time.Value = 0;
        UpdateProgress();
    }

    public void Update(float deltaTime)
    {
        if (_isRunning.Value == false)
            return;

        _time.Value += deltaTime;
        UpdateProgress();

        if (_time.Value >= _delay)
        {
            Finished?.Invoke();
            Reseter();
        }
    }

    private void UpdateProgress() => _progress.Value = _time.Value / _delay;
}
