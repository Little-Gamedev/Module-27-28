using TMPro;
using UnityEngine;

public class TimerSimpleView : TimerView
{
    [SerializeField] private TMP_Text _countTimerTMP;

    protected override void Show(float value) => _countTimerTMP.text = ((int)value).ToString();
}