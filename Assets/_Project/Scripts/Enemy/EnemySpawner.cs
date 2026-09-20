using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;
    [SerializeField] private Transform _parentTransformForEnemy;

    public Enemy Spawn(EnemySettings settings, Vector3 position)
    {
        Enemy prefab = null;

        if (settings is OrkSettings)
            prefab = _orkPrefab;
        else if (settings is ElfSettings)
            prefab = _elfPrefab;
        else if (settings is DragonSettings)
            prefab = _dragonPrefab;
        else
        {
            Debug.LogWarning("[EnemySpawner] Такого врага не существует");
            return null;
        }

        Enemy newEnemy = Instantiate(prefab, position, Quaternion.Euler(0f, 180f, 0f), _parentTransformForEnemy);
        newEnemy.Initialize(settings);

        return newEnemy;
    }
}
