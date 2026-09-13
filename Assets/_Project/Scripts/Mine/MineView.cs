using UnityEngine;

public class MineView : MonoBehaviour
{
    [SerializeField] private Mine _mine;

    [SerializeField] private GameObject _visual;

    [SerializeField] private GameObject _explosionParticlePrefab;
    [SerializeField] private float _particleDestroyDelay = 3f;

    private bool _isExplosionShown;

    private void Update()
    {
        if (_mine.IsExploded == false)
            return;

        if (_isExplosionShown)
            return;

        ShowExplosion();
    }

    private void ShowExplosion()
    {
        _isExplosionShown = true;

        SpawnExplosionParticle();

        Destroy(_visual);
    }

    private void SpawnExplosionParticle()
    {
        if (_explosionParticlePrefab == null)
            return;

        GameObject explosionParticle = Instantiate(_explosionParticlePrefab, transform.position, Quaternion.identity);

        Destroy(explosionParticle, _particleDestroyDelay);
    }
}