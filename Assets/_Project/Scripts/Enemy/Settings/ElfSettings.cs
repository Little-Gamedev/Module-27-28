using System;
using UnityEngine;

[Serializable]
public class ElfSettings : EnemySettings
{
    [SerializeField] private float _agility;
    public float Agility => _agility;
}
