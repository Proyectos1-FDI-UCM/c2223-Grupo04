using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosInGame : MonoBehaviour
{
    [SerializeField]
    DialogoSO _dialogos;
    [SerializeField]
    GameObject _dialogoPrefab;
    [SerializeField]
    GameObject _dialogoInstancia;
    [SerializeField]
    Transform _bocadilloSpawner;

    public void Bocadillo() 
    {
        if (_dialogoInstancia == null) 
        {
        
            _dialogoInstancia = Instantiate(_dialogoPrefab, _bocadilloSpawner);
            _dialogoInstancia.GetComponent<Bocadillo>().Escribir(_dialogos._dialogos[Random.Range(0, _dialogos._dialogos.Length)]);
        }
        else if (_dialogoInstancia != null) 
        {
            Destroy(_dialogoInstancia);
            _dialogoInstancia = Instantiate(_dialogoPrefab, _bocadilloSpawner);
            _dialogoInstancia.GetComponent<Bocadillo>().Escribir(_dialogos._dialogos[Random.Range(0, _dialogos._dialogos.Length)]);

        }

    }
    
}
