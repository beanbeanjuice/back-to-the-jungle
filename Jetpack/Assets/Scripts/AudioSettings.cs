using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Allows player to change audio mixer in settings menu.
/// <remarks>Coded by Westley.</remarks>
/// </summary>
public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }
}
