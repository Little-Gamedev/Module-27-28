using UnityEngine;

public class Dragon : Enemy
{
    private float _accumulationFire;

    public float AccumulationFire => _accumulationFire;
    public override string GetDescription() => $"{base.GetDescription()}\nОгонь: {AccumulationFire}";

    public override void Initialize(EnemySettings settings)
    {
        base.Initialize(settings);

        if (settings is DragonSettings dragonSettings)
            _accumulationFire = dragonSettings.AccumulationFire;
    }
}
