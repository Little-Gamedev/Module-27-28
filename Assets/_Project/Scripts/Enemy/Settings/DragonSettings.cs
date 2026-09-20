using System;
using UnityEngine;

[Serializable]
public class DragonSettings : EnemySettings
{
    [SerializeField] private float _accumulationFire;
    public float AccumulationFire => _accumulationFire;
}
