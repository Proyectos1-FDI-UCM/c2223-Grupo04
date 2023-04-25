using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioClip _chillMusic, _tornadoMusic;
    [SerializeField]
    private AudioSource _chillMus;
    [SerializeField]
    private AudioSource _torMus;
    [SerializeField]
    float _fadeoutMusic;

    public static SoundManager Instance;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        _fadeoutMusic = .5f;
        PlayChill();
    }

    private void Update()
    {
        if (_fadeoutMusic < 0.8f) 
        { 
            _fadeoutMusic += (Time.deltaTime/10); 
            _torMus.volume = 0.48f - _fadeoutMusic;
            _chillMus.volume = _fadeoutMusic;
        } 
        else if (_fadeoutMusic < 1)
        {
            _fadeoutMusic = 2;
        }
    }

    public void ChangeChill() 
    {
        PlayChill();
        _fadeoutMusic = 0;
    }

    public void ChangeTor()
    {
        PlayTornado();
        _torMus.volume = 0.48f;
        _chillMus.volume = 0;
    }

    void PlayChill(){ _chillMus.clip=_chillMusic; _chillMus.Play(); print("ER"); }

    void PlayTornado(){ _torMus.clip=_tornadoMusic; _torMus.Play();}
   
}
