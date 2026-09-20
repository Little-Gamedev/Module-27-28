using System;
using System.Collections.Generic;

public class OldEnemyDestroyer
{
    public event Action<OldEnemy> OldEnemyDestroyed;
    public event Action<int> CountChanged;

    private readonly List<OldEnemyWithCondition> _enemies = new List<OldEnemyWithCondition>();

    public int EnemiesCount => _enemies.Count;

    public void Register(OldEnemy enemy, Func<bool> condition)
    {
        OldEnemyWithCondition enemyWithCondition = new OldEnemyWithCondition();
        enemyWithCondition.OldEnemy = enemy;
        enemyWithCondition.Condition = condition;

        _enemies.Add(enemyWithCondition);

        CountChanged?.Invoke(EnemiesCount);
    }

    public void Update()
    {
        List<OldEnemyWithCondition> readyToDestroy = new List<OldEnemyWithCondition>();

        foreach (OldEnemyWithCondition enemyWithCondition in _enemies)
        {
            if (enemyWithCondition.Condition() == false)
                continue;

            readyToDestroy.Add(enemyWithCondition);
        }

        if (readyToDestroy.Count == 0)
            return;

        foreach (OldEnemyWithCondition enemyWithCondition in readyToDestroy)
        {
            _enemies.Remove(enemyWithCondition);
            OldEnemyDestroyed?.Invoke(enemyWithCondition.OldEnemy);
        }

        CountChanged?.Invoke(EnemiesCount);
    }
}