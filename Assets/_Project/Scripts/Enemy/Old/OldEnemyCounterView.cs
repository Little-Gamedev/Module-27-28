using TMPro;
using UnityEngine;

public class OldEnemyCounterView : MonoBehaviour
{
    [SerializeField] private OldEnemyDestroyerHolder _oldEnemyDestroyerHolder;
    [SerializeField] private TMP_Text _countTMP;

    private void Start()
    {
        _oldEnemyDestroyerHolder.OldEnemyDestroyer.CountChanged += UpdateCount;

        UpdateCount(_oldEnemyDestroyerHolder.OldEnemyDestroyer.EnemiesCount);
    }

    private void OnDestroy()
    {
        _oldEnemyDestroyerHolder.OldEnemyDestroyer.CountChanged -= UpdateCount;
    }

    private void UpdateCount(int count) => _countTMP.text = count.ToString();
}