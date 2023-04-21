using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    GameObject _resumen; //resumen

    [SerializeField]
    Sprite[] _npcs; //sprites a poner en los resumenes

    [SerializeField]
    GameObject[] _niveles; //botones de los niveles

    int _nivel; // nivel a poner en el resumen
    string _nombre; // nombre del vecino a poner en el resumen

    //cambia a la escena del index indicado
    public void CambiaEscena2(int numeroEscena) 
    {
        SceneManager.LoadScene(_nivel + 2);
    }

    //actualiza el nivel del resumen
    public void Nivel(int nivel){ _nivel = nivel; }
    //actualiza el nivel del resumen
    public void Nombre(string nombre) { _nombre = nombre; }

    //actualiza el resumen
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
        // Desactiva todos los niveles.
        _resumen.SetActive(false);
        for (int i = 0; i < _niveles.Length; i++)
        {
            _niveles[i].SetActive(false);
        }
    }

    private void Start()
    {
        // Activa los botones de los niveles.
        if (Puntuacion.Instance == null)
        {
            new GameObject("Puntuacion",typeof(Puntuacion));
            Puntuacion.Instance.SetNivelActual(1);
        }
        for (int i = 0; i < Puntuacion.Instance.GetNivelActual(); i++)
        {
            _niveles[i].SetActive(true);
        }
    }
}
