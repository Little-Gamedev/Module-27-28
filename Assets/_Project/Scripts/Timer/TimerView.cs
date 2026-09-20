using UnityEngine;

public abstract class TimerView : MonoBehaviour
{
    private IReadOnlyVariable<float> _time;

    public void Initialize(IReadOnlyVariable<float> time)
    {
        _time = time;
        _time.Changed += OnTimeChanged;

        Show(_time.Value);
    }

    private void OnDestroy()
    {
        if (_time == null)
            return;

        _time.Changed -= OnTimeChanged;
    }

    private void OnTimeChanged(float oldValue, float newValue) => Show(newValue);

    protected abstract void Show(float value);
}