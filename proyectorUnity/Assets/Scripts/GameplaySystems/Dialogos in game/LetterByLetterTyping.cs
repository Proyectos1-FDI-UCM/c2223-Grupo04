using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterByLetterTyping : MonoBehaviour
{

    float _delay;
    float _delayReset;
    TextMeshProUGUI _dialogos;
    string _dialogue;
    int _controlVar = 0;


    // Update is called once per frame
    void Update()
    {

        if (_controlVar < _dialogue.Length) 
        { 
            if (_delay <= 0f) 
            {
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
}
