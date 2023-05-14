using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject _imagenLogo;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _clip;
    Vector3 escala;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroScene()); // Llamamos a la corrutina.
        escala = _imagenLogo.transform.localScale;
        escala = new Vector3(0.01f, 0.01f, 0.01f);
    }
    private void Update()
    {
        AumentaLogo();   
    }
    IEnumerator IntroScene() // Corrutina para la intro.
    {
        _audioSource.PlayOneShot(_clip);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(1); // Carga la escena del menu inicial.
    }
    void AumentaLogo() // Para aumentar la escala del logo de la intro.
    {
        if (_imagenLogo.transform.localScale.x < 1f) 
        {
            escala.x += 0.01f;
            escala.y += 0.01f;
            escala.z += 0.01f;
            _imagenLogo.transform.localScale = escala;
        }
    }
}
