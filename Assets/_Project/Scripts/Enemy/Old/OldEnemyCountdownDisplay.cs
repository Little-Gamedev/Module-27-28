using System.Collections;
using TMPro;
using UnityEngine;

public class OldEnemyCountdownDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private TMP_Text _countdownText;
    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _finishedColor = Color.red;

    public void StartCountdown(float duration)
    {
        _root.SetActive(true);
        _countdownText.color = _normalColor;

        StartCoroutine(CountdownRoutine(duration));
    }

    private IEnumerator CountdownRoutine(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            _countdownText.text = Mathf.CeilToInt(duration - elapsed).ToString();

            yield return null;
            elapsed += Time.deltaTime;
        }

        _countdownText.text = "0";
        _countdownText.color = _finishedColor;
    }
}