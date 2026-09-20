using UnityEngine;

public class Example : MonoBehaviour
{
    private const int EnemiesPerType = 3;

    [SerializeField] private OrkSettings[] _orksEnemySettings;
    [SerializeField] private ElfSettings[] _elfsEnemySettings;
    [SerializeField] private DragonSettings[] _dragonsEnemySettings;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private int _spacing = 2;

    private int _positionX = 0;

    private void Awake()
    {
        SpawnEnemies(_orksEnemySettings);
        SpawnEnemies(_elfsEnemySettings);
        SpawnEnemies(_dragonsEnemySettings);
    }

    private void SpawnEnemies(EnemySettings[] settings)
    {
        if (settings.Length == 0)
        {
            Debug.LogWarning("[Example] Массив настроек пуст");

            return;
        }

        for (int i = 0; i < EnemiesPerType; i++)
        {
            EnemySettings randomSettings = settings[Random.Range(0, settings.Length)];

            _enemySpawner.Spawn(randomSettings, new Vector3(_positionX, 0, 0));
            _positionX += _spacing;
        }
    }
}