using UnityEngine;

public class EnemyDestroyerHolder : MonoBehaviour
{
    public EnemyDestroyer EnemyDestroyer => _enemyDestroyer;

    private EnemyDestroyer _enemyDestroyer;

    private void Awake()
    {
        _enemyDestroyer = new EnemyDestroyer();
        _enemyDestroyer.EnemyDestroyed += OnEnemyDestroyed;
    }

    private void OnDestroy()
    {
        _enemyDestroyer.EnemyDestroyed -= OnEnemyDestroyed;
    }

    private void Update()
    {
        _enemyDestroyer.Update();
    }

    private void OnEnemyDestroyed(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}