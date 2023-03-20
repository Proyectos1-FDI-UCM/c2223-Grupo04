using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    GameObject _resumen;

    [SerializeField]
    Sprite[] _npcs;

    [SerializeField]
    GameObject[] _niveles;

    int _nivel;
    string _nombre;

    public void CambiaEscena2(int numeroEscena) 
    {
        SceneManager.LoadScene(_nivel + 2);
    }

    public void Nivel(int nivel){ _nivel = nivel; }
    public void Nombre(string nombre) { _nombre = nombre; }

    public void Resumen()
    {
        _resumen.SetActive(true);
        _resumen.GetComponent<ResumenNivel>().UpdateResumen(_nombre, Puntuacion.Instance.GetNumeroTornados(_nivel), Puntuacion.Instance.GetNumeroPlantasSecas(_nivel), _npcs[_nivel]);
    }

    public void ExitBoton()
    {
        SceneManager.LoadScene("MENU INICIAL");
    }
    private void Awake()
    {
        _resumen.SetActive(false);
        for (int i = 0; i < _niveles.Length; i++)
        {
            _niveles[i].SetActive(false);
        }
    }

    private void Start()
    {
        for (int i = 0; i < Puntuacion.Instance.GetNivelActual(); i++)
        {
            _niveles[i].SetActive(true);
        }
    }
}
