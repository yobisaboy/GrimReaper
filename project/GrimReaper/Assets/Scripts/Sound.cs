using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    public AudioMixerGroup mixerGroup;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    //play on awake
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
