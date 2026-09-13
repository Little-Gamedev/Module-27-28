using System;
using System.Collections.Generic;

public class EnemyDestroyer
{
    public event Action<Enemy> EnemyDestroyed;
    public event Action<int> CountChanged;

    private readonly List<EnemyWithCondition> _enemies = new List<EnemyWithCondition>();

    public int EnemiesCount => _enemies.Count;

    public void Register(Enemy enemy, Func<bool> condition)
    {
        EnemyWithCondition enemyWithCondition = new EnemyWithCondition();
        enemyWithCondition.Enemy = enemy;
        enemyWithCondition.Condition = condition;

        _enemies.Add(enemyWithCondition);

        CountChanged?.Invoke(EnemiesCount);
    }

    public void Update()
    {
        List<EnemyWithCondition> readyToDestroy = new List<EnemyWithCondition>();

        foreach (EnemyWithCondition enemyWithCondition in _enemies)
        {
            if (enemyWithCondition.Condition() == false)
                continue;

            readyToDestroy.Add(enemyWithCondition);
        }

        if (readyToDestroy.Count == 0)
            return;

        foreach (EnemyWithCondition enemyWithCondition in readyToDestroy)
        {
            _enemies.Remove(enemyWithCondition);
            EnemyDestroyed?.Invoke(enemyWithCondition.Enemy);
        }

        CountChanged?.Invoke(EnemiesCount);
    }
}