using UnityEngine;

public class EnemyTestSpawner : MonoBehaviour
{
    [SerializeField] private EnemyDestroyerHolder _enemyDestroyerHolder;
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private Transform _manualKillSpawnPoint;
    [SerializeField] private Transform _timedKillSpawnPoint;
    [SerializeField] private Transform _countKillSpawnPoint;
    [SerializeField] private float _deathDelayAfterCountdown = 1f;

    [SerializeField] private float _lifetimeThreshold = 5f;
    [SerializeField] private int _countThreshold = 2;

    [SerializeField] private Color _manualKillColor = Color.red;
    [SerializeField] private Color _timedKillColor = Color.blue;
    [SerializeField] private Color _countKillColor = Color.magenta;

    private Enemy _manualKillEnemy;
    private Enemy _timedKillEnemy;
    private Enemy _countKillEnemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
            SpawnManualKillEnemy();

        if (Input.GetKeyDown(KeyCode.Alpha8))
            SpawnTimedKillEnemy();

        if (Input.GetKeyDown(KeyCode.Alpha9))
            SpawnCountKillEnemy();
    }

    private void SpawnManualKillEnemy()
    {
        if (_manualKillEnemy != null)
            return;

        _manualKillEnemy = Instantiate(_enemyPrefab, _manualKillSpawnPoint.position, _manualKillSpawnPoint.rotation);
        _manualKillEnemy.SetColor(_manualKillColor);

        _enemyDestroyerHolder.EnemyDestroyer.Register(_manualKillEnemy, () => _manualKillEnemy.IsDead);
    }

    private void SpawnTimedKillEnemy()
    {
        if (_timedKillEnemy != null)
            return;

        _timedKillEnemy = Instantiate(_enemyPrefab, _timedKillSpawnPoint.position, _timedKillSpawnPoint.rotation);
        _timedKillEnemy.SetColor(_timedKillColor);

        float spawnTime = Time.time;
        float destroyDelay = _lifetimeThreshold + _deathDelayAfterCountdown;

        _enemyDestroyerHolder.EnemyDestroyer.Register(_timedKillEnemy, () => Time.time - spawnTime > destroyDelay);

        EnemyCountdownDisplay countdownDisplay = _timedKillEnemy.GetComponentInChildren<EnemyCountdownDisplay>(true);

        if (countdownDisplay != null)
            countdownDisplay.StartCountdown(_lifetimeThreshold);
    }

    private void SpawnCountKillEnemy()
    {
        if (_countKillEnemy != null)
            return;

        _countKillEnemy = Instantiate(_enemyPrefab, _countKillSpawnPoint.position, _countKillSpawnPoint.rotation);
        _countKillEnemy.SetColor(_countKillColor);

        _enemyDestroyerHolder.EnemyDestroyer.Register(_countKillEnemy, () => _enemyDestroyerHolder.EnemyDestroyer.EnemiesCount > _countThreshold);
    }
}