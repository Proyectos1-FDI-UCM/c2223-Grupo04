using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterByLetterTyping : MonoBehaviour
{

    //Variables locales
    float _delay;
    float _delayReset;
    TextMeshProUGUI _dialogos;
    string _dialogue = "";
    int _controlVar = 0;
    
    //SOUND
    [SerializeField] private AudioClip _dialogueTypingSounds;
    [SerializeField] private bool _stopAudioSource;

    private AudioSource _audioTrack;

    [SerializeField] private int _frequencylevel;

    [Range(-3, 3)]
    [SerializeField] float _minPitch = 0.5f;

    [Range(-3, 3)]
    [SerializeField] float _maxPitch = 3f;


    // Update is called once per frame
    void Update()
    {

        if (_controlVar < _dialogue.Length) 
        {
            
            if (_delay <= 0f) 
            {
                PlayDialogueSound(_controlVar);
                print(_controlVar);
                _dialogos.text += _dialogue[_controlVar];
                
                _controlVar++;
                _delay = _delayReset;
            }
            else _delay -= Time.deltaTime;
        }
        

    }
    public void LetterByLetter(string dialogue, TextMeshProUGUI dialogues, float delay) 
    {

        _controlVar = 0;
        _dialogue = dialogue;
        _dialogos = dialogues;
        _delay = delay;
        _delayReset = _delay;
    }
    public void StopWriting() 
    {
        _controlVar = 0;
        _dialogue = ""; 
    }
    
    private void PlayDialogueSound(int currentDisplayedCharCount) 
    {
        if(currentDisplayedCharCount % _frequencylevel == 0)
        {
            _audioTrack = this.gameObject.AddComponent<AudioSource>();
            if (_stopAudioSource)
            {
                _audioTrack.Stop();
            }
            _audioTrack.pitch = Random.Range(_minPitch, _maxPitch);
            _audioTrack.PlayOneShot(_dialogueTypingSounds);
        } 
    }
}
