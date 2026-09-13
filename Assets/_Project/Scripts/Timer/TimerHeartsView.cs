using System.Collections.Generic;
using UnityEngine;

public class TimerHeartsView : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private TimerHolder _timerHolder;
    [SerializeField] private Transform _parentTransform;

    private List<GameObject> _hearts = new List<GameObject>();

    private void Start() => _timerHolder.ChangedState += UpdateHearts;

    private void OnDestroy() => _timerHolder.ChangedState -= UpdateHearts;

    private void UpdateHearts(bool active, float time)
    {
        int currentWholeSeconds = (int)time;

        if (currentWholeSeconds < _hearts.Count)
        {
            foreach (GameObject heart in _hearts)
                Destroy(heart);

            _hearts.Clear();
        }

        while (_hearts.Count < currentWholeSeconds)
            _hearts.Add(Instantiate(_heartPrefab, _parentTransform));
    }
}