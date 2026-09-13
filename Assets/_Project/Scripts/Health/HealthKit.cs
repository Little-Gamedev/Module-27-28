using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private int _healthRestore = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealable healable))
        {
            healable.Heal(_healthRestore);

            Destroy(gameObject);
        }
    }
}