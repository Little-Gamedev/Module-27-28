using System;
using UnityEngine;

public class TestStarterTimer : MonoBehaviour
{
    [SerializeField] private TimerHolder _timerHolder;
    [SerializeField] private KeyCode _resumeButton;
    [SerializeField] private KeyCode _pauseButton;
    [SerializeField] private KeyCode _resetButton;

    private void Update()
    {
        if (Input.GetKeyDown(_resumeButton))
            _timerHolder.Resume();
        if (Input.GetKeyDown(_pauseButton))
            _timerHolder.Pause();
        if (Input.GetKeyDown(_resetButton))
            _timerHolder.Reseter();
    }
}
