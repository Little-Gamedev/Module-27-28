using System.Collections.Generic;
using UnityEngine;

public class TimerHeartsView : TimerView
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private Transform _parentTransform;

    private List<GameObject> _hearts = new List<GameObject>();

    protected override void Show(float value)
    {
        int currentWholeSeconds = (int)value;

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