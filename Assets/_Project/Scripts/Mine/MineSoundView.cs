using System.Collections;
using UnityEngine;

public class MineSoundView : MonoBehaviour
{
    [SerializeField] private Mine _mine;
    [SerializeField] private AudioSource _audioSource;

    private bool _isExplosionSoundPlayed;

    private void Update()
    {
        if (_mine.IsExploded == false)
            return;

        if (_isExplosionSoundPlayed)
            return;

        StartCoroutine(PlayExplosionSound());
    }

    private IEnumerator PlayExplosionSound()
    {
        _isExplosionSoundPlayed = true;

        _audioSource.Play();

        yield return new WaitWhile(() => _audioSource.isPlaying);

        Destroy(_mine.gameObject);
    }
}