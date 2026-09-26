using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;
    [SerializeField] private Transform _parentTransformForEnemy;

    private readonly Quaternion _spawnRotation = Quaternion.Euler(0f, 180f, 0f);

    public Enemy Spawn(EnemySettings settings, Vector3 position)
    {
        if (settings is OrkSettings orkSettings)
        {
            Ork ork = Instantiate(_orkPrefab, position, _spawnRotation, _parentTransformForEnemy);
            ork.Initialize(orkSettings);

            return ork;
        }

        if (settings is ElfSettings elfSettings)
        {
            Elf elf = Instantiate(_elfPrefab, position, _spawnRotation, _parentTransformForEnemy);
            elf.Initialize(elfSettings);

            return elf;
        }

        if (settings is DragonSettings dragonSettings)
        {
            Dragon dragon = Instantiate(_dragonPrefab, position, _spawnRotation, _parentTransformForEnemy);
            dragon.Initialize(dragonSettings);

            return dragon;
        }

        Debug.LogWarning("[EnemySpawner] Такого врага не существует. Вот такая вот хуйня собачка...");

        return null;
    }
}