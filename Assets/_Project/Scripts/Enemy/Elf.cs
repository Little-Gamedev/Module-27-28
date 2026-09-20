using UnityEngine;

public class Elf : Enemy
{
    private float _agility;

    public float Agility => _agility;
    public override string GetDescription() => $"{base.GetDescription()}\nЛовкость: {Agility}";

    public override void Initialize(EnemySettings settings)
    {
        base.Initialize(settings);

        if (settings is ElfSettings elfSettings)
            _agility = elfSettings.Agility;
    }
}
