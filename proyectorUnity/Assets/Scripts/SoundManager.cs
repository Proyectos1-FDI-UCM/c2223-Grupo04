using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioClip _chillMusic, _tornadoMusic;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayChill(){_audioSource.Stop(); _audioSource.clip=_chillMusic; _audioSource.Play();}

    public void PlayTornado(){_audioSource.Stop(); _audioSource.clip=_tornadoMusic; _audioSource.Play();}
}
