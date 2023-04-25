using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;

    //[SerializeField] private AudioMixer _capybaraAudioMixer;
    //public void SetVolume(float sliderValue) 
    //{
    //    _capybaraAudioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    //}
    public void ChangeVolume() 
    {
        AudioListener.volume = _volumeSlider.value;
    
    }
}
