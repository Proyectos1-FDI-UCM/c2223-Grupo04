using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    GameObject _resumen; //resumen

    [SerializeField]
    Animator _transition;

    [SerializeField]
    Sprite[] _npcs; //sprites a poner en los resumenes

    [SerializeField]
    GameObject[] _niveles; //botones de los niveles

    int _nivel; // nivel a poner en el resumen
    string _nombre; // nombre del vecino a poner en el resumen
    [SerializeField]
    SombraComponentUI _sombra;

    //SOUNDS
    MenuSounds _menuSounds;

    //cambia a la escena del index indicado
    public void CambiaEscena2()
    {
        StartCoroutine(LoadLevel(_nivel + 2));
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
        _sombra.UpdateSadow();
        _menuSounds.ButtonSound();
    }

    public void ExitBoton()
    {
        _menuSounds.ButtonSound();
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _menuSounds.ButtonSound();
        _transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);
        
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
        _menuSounds = GetComponent<MenuSounds>();
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
