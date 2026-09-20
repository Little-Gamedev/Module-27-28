using UnityEngine;

public class OldEnemyDestroyerHolder : MonoBehaviour
{
    public OldEnemyDestroyer OldEnemyDestroyer => _oldEnemyDestroyer;

    private OldEnemyDestroyer _oldEnemyDestroyer;

    private void Awake()
    {
        _oldEnemyDestroyer = new OldEnemyDestroyer();
        _oldEnemyDestroyer.OldEnemyDestroyed += OnOldEnemyDestroyed;
    }

    private void OnDestroy()
    {
        _oldEnemyDestroyer.OldEnemyDestroyed -= OnOldEnemyDestroyed;
    }

    private void Update()
    {
        _oldEnemyDestroyer.Update();
    }

    private void OnOldEnemyDestroyed(OldEnemy oldEnemy)
    {
        Destroy(oldEnemy.gameObject);
    }
}