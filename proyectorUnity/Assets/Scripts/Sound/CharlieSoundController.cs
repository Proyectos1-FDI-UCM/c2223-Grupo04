using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlieSoundController : MonoBehaviour
{
    //Variables locales para sonidos de charlie
    int _sonidoPasos; 
    //Sonidos
    private AudioSource _charlie;
    [SerializeField] private AudioClip[] _charlieCamina;
    //Variable que aloja la pista de pisadas de Charlie
    int _currentCharlieTrack = -1;
    //Pitch
    /*[Range(-3, 3)]
    [SerializeField] float _minPitch;

    [Range(-3, 3)]
    [SerializeField] float _maxPitch;*/

    // Start is called before the first frame update
    void Start()
    {
        _charlie = this.gameObject.AddComponent<AudioSource>();
        _charlie.volume = 3;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharlieCamina() 
    {
        int currentCharlie = Random.Range(0, _charlieCamina.Length);
        while (_currentCharlieTrack == currentCharlie) 
        {
            currentCharlie = Random.Range(0, _charlieCamina.Length);
        }
        _charlie.PlayOneShot(_charlieCamina[currentCharlie]);
        _currentCharlieTrack = currentCharlie;

    }
    
}
