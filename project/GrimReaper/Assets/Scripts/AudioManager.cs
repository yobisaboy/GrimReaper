using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject music;
    [SerializeField] GameObject sound;
    [SerializeField] GameObject musicOption;
    [SerializeField] GameObject soundOption;
    public AudioMixer soundMixer;
    public float musicVolumeLevel;
    public float soundVolumeLevel;


    public void Start()
    {
        music.SetActive(true);
        sound.SetActive(true);
    }

    public void Update()
    {
        MusicVolume();
        SoundVolume();
    }   

    // Slider control for music volume
    public void MusicVolume()
    {        
        music.GetComponent<AudioSource>().volume = musicOption.GetComponent<Slider>().value;
    }

    // Slider control for sound volume
    public void SoundVolume()
    {
        soundMixer.SetFloat("musicVol", soundOption.GetComponent<Slider>().value);
    }

}
