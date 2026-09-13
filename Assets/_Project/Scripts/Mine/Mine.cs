using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _activationRadius = 2f;
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _explosionDelay = 1f;
    [SerializeField] private int _damage = 40;

    private bool _isActivated;

    public bool IsExploded { get; private set; }

    private void Update()
    {
        if (_isActivated)
            return;

        TryActivate();
    }

    private void TryActivate()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _activationRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable damageable))
            {
                Activate();
                return;
            }
        }
    }

    private void Activate()
    {
        _isActivated = true;

        StartCoroutine(ExplosionDelay());
    }

    private IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(_explosionDelay);

        Explode();
    }

    private void Explode()
    {
        IsExploded = true;

        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, _activationRadius);

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}