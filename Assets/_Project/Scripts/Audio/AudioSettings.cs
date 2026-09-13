using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private const float EnabledVolume = 0f;
    private const float DisabledVolume = -80f;

    [SerializeField] private AudioMixer _audioMixer;

    private bool _isMusicEnabled = true;
    private bool _isSfxEnabled = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ToggleMusic();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ToggleSfx();
    }

    public void ToggleMusic()
    {
        _isMusicEnabled = !_isMusicEnabled;

        if (_isMusicEnabled)
            _audioMixer.SetFloat("MusicVolume", EnabledVolume);
        else
            _audioMixer.SetFloat("MusicVolume", DisabledVolume);
    }

    public void ToggleSfx()
    {
        _isSfxEnabled = !_isSfxEnabled;

        if (_isSfxEnabled)
            _audioMixer.SetFloat("SFXVolume", EnabledVolume);
        else
            _audioMixer.SetFloat("SFXVolume", DisabledVolume);
    }
}
