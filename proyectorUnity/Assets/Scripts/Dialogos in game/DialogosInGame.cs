using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosInGame : MonoBehaviour
{
    [SerializeField]
    DialogoSO _dialogos;
    GameObject _dialogoPrefab;
    GameObject _dialogoInstancia;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
