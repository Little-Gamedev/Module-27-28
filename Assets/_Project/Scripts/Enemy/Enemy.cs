using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySettings _enemySettings;

    public float Damage => _enemySettings.Damage;
    public virtual string GetDescription() => $"Урон: {Damage}";

    public virtual void Initialize(EnemySettings settings) => _enemySettings = settings;
}
