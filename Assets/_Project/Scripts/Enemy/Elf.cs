public class Elf : Enemy
{
    private float _agility;

    public float Agility => _agility;

    public override string GetDescription() => $"{base.GetDescription()}\nЛовкость: {Agility}";

    public void Initialize(ElfSettings settings)
    {
        ApplySettings(settings);
        _agility = settings.Agility;
    }
}
