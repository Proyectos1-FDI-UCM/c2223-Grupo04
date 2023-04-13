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
    [SerializeField] private AudioClip[] _dialogueTypingSounds;
    [SerializeField] private bool _stopAudioSource;

    private AudioSource _audioTrack;

    [SerializeField] private int _frequencylevel;

    [Range(-3, 3)]
    [SerializeField] float _minPitch = 0.5f;

    [Range(-3, 3)]
    [SerializeField] float _maxPitch = 3f;

    private void Start()
    {
        _audioTrack = this.gameObject.AddComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

        if (_controlVar < _dialogue.Length) 
        {
            
            if (_delay <= 0f) 
            {
                PlayDialogueSound(_controlVar);
                _dialogos.text += _dialogue[_controlVar];
                
                _controlVar++;
                _delay = _delayReset;

                
            }
            else _delay -= Time.deltaTime;
        }
        

    }
    public void LetterByLetter(string dialogue, TextMeshProUGUI dialogues, float delay = 0.045f) 
    {
        dialogues.text = "";

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
            if (_stopAudioSource)
            {
                _audioTrack.Stop();
            }
  
            AudioClip currentSound = _dialogueTypingSounds[Random.Range(0, _dialogueTypingSounds.Length)];
            _audioTrack.pitch = Random.Range(_minPitch, _maxPitch);

            int chr = _dialogue[_controlVar];

            if (chr == 129 || chr == 161) { currentSound = _dialogueTypingSounds[1]; }
            else if (chr == 137 || chr == 169) { currentSound = _dialogueTypingSounds[5]; }
            else if (chr == 141 || chr == 173) { currentSound = _dialogueTypingSounds[9]; }
            else if (chr == 147 || chr == 179) { currentSound = _dialogueTypingSounds[15]; }
            else if (chr == 154 || chr == 186) { currentSound = _dialogueTypingSounds[21]; }
            else if (chr == 177 || chr == 145) { currentSound = _dialogueTypingSounds[0]; }
            else if (chr > 66 || chr < 91) { currentSound = _dialogueTypingSounds[chr / 66]; }
            else if (chr > 34 || chr < 59) { currentSound = _dialogueTypingSounds[chr / 34]; }
            else currentSound = _dialogueTypingSounds[1];

            /*//TODO ESTE SWTICH ESTÁ EN VERSIÓN PRELIMINAR, SE VA A INTENTAR HACER CON LOS CARACTERES ASCII DE CADA LETRA PARA EVITAR ERRORES
            switch (_dialogue[_controlVar]) 
            {
                case 'A':
                    currentSound = _dialogueTypingSounds[0];
                    break;
                case 'B':
                    currentSound = _dialogueTypingSounds[1];
                    break;
                case 'C':
                    currentSound = _dialogueTypingSounds[2];
                    break;
                case 'D':
                    currentSound = _dialogueTypingSounds[3];
                    break;
                case 'E':
                    currentSound = _dialogueTypingSounds[4];
                    break;
                case 'F':
                    currentSound = _dialogueTypingSounds[5];
                    break;
                case 'G':
                    currentSound = _dialogueTypingSounds[6];
                    break;
                case 'H':
                    currentSound = _dialogueTypingSounds[7];
                    break;
                case 'I':
                    currentSound = _dialogueTypingSounds[8];
                    break;
                case 'J':
                    currentSound = _dialogueTypingSounds[9];
                    break;
                case 'K':
                    currentSound = _dialogueTypingSounds[10];
                    break;
                case 'L':
                    currentSound = _dialogueTypingSounds[11];
                    break;
                case 'M':
                    currentSound = _dialogueTypingSounds[12];
                    break;
                case 'N':
                    currentSound = _dialogueTypingSounds[13];
                    break;
                case 'Ñ':
                    currentSound = _dialogueTypingSounds[14];
                    break;
                case 'O':
                    currentSound = _dialogueTypingSounds[15];
                    break;
                case 'P':
                    currentSound = _dialogueTypingSounds[16];
                    break;
                case 'Q':
                    currentSound = _dialogueTypingSounds[17];
                    break;
                case 'R':
                    currentSound = _dialogueTypingSounds[18];
                    break;
                case 'S':
                    currentSound = _dialogueTypingSounds[19];
                    break;
                case 'T':
                    currentSound = _dialogueTypingSounds[20];
                    break;
                case 'U':
                    currentSound = _dialogueTypingSounds[21];
                    break;
                case 'V':
                    currentSound = _dialogueTypingSounds[22];
                    break;
                case 'W':
                    currentSound = _dialogueTypingSounds[23];
                    break;
                case 'X':
                    currentSound = _dialogueTypingSounds[24];
                    break;
                case 'Y':
                    currentSound = _dialogueTypingSounds[25];
                    break;
                case 'Z':
                    currentSound = _dialogueTypingSounds[26];
                    break;
            }*/
            _audioTrack.PlayOneShot(currentSound);
        } 
    }
}
