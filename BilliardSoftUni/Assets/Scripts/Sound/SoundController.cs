using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SoundController : MonoBehaviour {    
    public AudioSource musicClip;
    public AudioSource soundClip;
    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;

    public float musicVolume = 0.6f;
    public float soundVolume = 0.6f;
    

    void Start ()
    {
        //musicVolumeSlider = GameObject.Find("Music Volume Slider").GetComponent<Slider>();
        //soundVolumeSlider = GameObject.Find("Sound Volume Slider").GetComponent<Slider>();


        musicVolumeSlider.value = musicVolume * 100;
        soundVolumeSlider.value = soundVolume * 100;
        
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        soundVolumeSlider.onValueChanged.AddListener(delegate { OnSoundVolumeChange(); });

        OnMusicVolumeChange();
        OnSoundVolumeChange();

    }

    public void OnMusicVolumeChange ()
    {
        musicVolume = musicVolumeSlider.value * 0.01f;

        musicClip.volume = musicVolume;

    }

    public void OnSoundVolumeChange()
    {
        soundVolume = musicVolumeSlider.value * 0.01f;
    }

    public void BallHit ()
    {
        soundClip.Play();
    }
    

}
