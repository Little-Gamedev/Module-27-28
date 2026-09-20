using System;
using UnityEngine;

[Serializable]
public class EnemySettings
{
    [SerializeField] private float _damage;
    public float Damage => _damage;
}
