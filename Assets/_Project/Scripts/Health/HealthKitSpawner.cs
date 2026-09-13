using System.Collections;
using UnityEngine;

public class HealthKitSpawner : MonoBehaviour
{
    [SerializeField] private Transform _character;

    [SerializeField] private HealthKit _healthKitPrefab;

    [SerializeField] private float _spawnDelay = 5f;
    [SerializeField] private float _spawnDistance = 5f;

    private Coroutine _spawnProcess;

    private bool IsActive => _spawnProcess != null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            ToggleSpawner();
    }

    private void ToggleSpawner()
    {
        if (IsActive)
        {
            DisableSpawner();
            return;
        }

        EnableSpawner();
    }

    private void EnableSpawner()
    {
        _spawnProcess = StartCoroutine(SpawnProcess());
    }

    private void DisableSpawner()
    {
        StopCoroutine(_spawnProcess);

        _spawnProcess = null;
    }

    private IEnumerator SpawnProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            SpawnHealthKit();
        }
    }

    private void SpawnHealthKit()
    {
        float angle = Random.Range(0f, 360f);

        float angleInRadians = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(angleInRadians), 0f, Mathf.Sin(angleInRadians));

        Vector3 spawnPosition = _character.position + direction * _spawnDistance;

        Instantiate(_healthKitPrefab, spawnPosition, Quaternion.identity);
    }
}