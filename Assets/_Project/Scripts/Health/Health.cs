public class Health
{
    private readonly int _maxHealth;
    private readonly float _woundedPercent;

    private int _currentHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public bool IsDead => _currentHealth <= 0;

    public bool IsWounded
    {
        get
        {
            float woundedHealthLimit = _maxHealth * _woundedPercent;
            return _currentHealth <= woundedHealthLimit;
        }
    }

    public Health(int maxHealth, float woundedPercent)
    {
        _maxHealth = maxHealth;
        _woundedPercent = woundedPercent;
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead)
            return;

        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;
    }

    public void Heal(int health)
    {
        if (IsDead)
            return;

        _currentHealth += health;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
}