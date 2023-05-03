using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer _effectsAudioMixer;
    [SerializeField] private AudioMixer _musicAudioMixer;

    public void SetEffectsVolume(float sliderValue)
    {
        _effectsAudioMixer.SetFloat("MasterEffectsVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVolume(float sliderValue)
    {
        _musicAudioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
    /*public void ChangeVolume() 
    {
        AudioListener.volume = _volumeSlider.value;
    
    }*/
}
