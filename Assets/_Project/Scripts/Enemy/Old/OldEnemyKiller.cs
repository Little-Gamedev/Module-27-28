using UnityEngine;

public class OldEnemyKiller : MonoBehaviour
{
    [SerializeField] private float _killRadius = 2f;
    [SerializeField] private KeyCode _killButton;

    private void Update()
    {
        if (Input.GetKeyDown(_killButton))
            TryKillNearbyEnemies();
    }

    private void TryKillNearbyEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _killRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out OldEnemy enemy))
                enemy.Die();
        }
    }
}