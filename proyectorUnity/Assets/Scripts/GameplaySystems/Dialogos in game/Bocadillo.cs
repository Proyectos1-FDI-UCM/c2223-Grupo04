using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bocadillo : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _txtDialogo;
    float _countdown;

    private void Update()
    {
        if (_countdown <= 0) 
        {
            Destroy(gameObject);
        }
        else
        {
            _countdown -= Time.deltaTime;
        }
    }

    public void Escribir(string dialogo)
    {
        GameManager.Instance._letterTyper.LetterByLetter(dialogo, _txtDialogo);
        _countdown = 15;
    }
    
}
