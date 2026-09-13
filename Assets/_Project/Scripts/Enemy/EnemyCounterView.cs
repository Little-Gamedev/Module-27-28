using TMPro;
using UnityEngine;

public class EnemyCounterView : MonoBehaviour
{
    [SerializeField] private EnemyDestroyerHolder _enemyDestroyerHolder;
    [SerializeField] private TMP_Text _countTMP;

    private void Start()
    {
        _enemyDestroyerHolder.EnemyDestroyer.CountChanged += UpdateCount;

        UpdateCount(_enemyDestroyerHolder.EnemyDestroyer.EnemiesCount);
    }

    private void OnDestroy()
    {
        _enemyDestroyerHolder.EnemyDestroyer.CountChanged -= UpdateCount;
    }

    private void UpdateCount(int count) => _countTMP.text = count.ToString();
}