public class Dragon : Enemy
{
    private float _accumulationFire;

    public float AccumulationFire => _accumulationFire;

    public override string GetDescription() => $"{base.GetDescription()}\nОгонь: {AccumulationFire}";

    public void Initialize(DragonSettings settings)
    {
        ApplySettings(settings);
        _accumulationFire = settings.AccumulationFire;
    }
}
