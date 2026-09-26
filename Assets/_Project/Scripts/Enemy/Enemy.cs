using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private EnemySettings _enemySettings;

    public float Damage => _enemySettings.Damage;

    public virtual string GetDescription() => $"Урон: {Damage}";

    protected void ApplySettings(EnemySettings settings) => _enemySettings = settings;
}
