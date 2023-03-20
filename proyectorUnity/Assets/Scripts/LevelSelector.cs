using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    GameObject _playPrefab;

    public void CambiaEscena2(int numeroEscena) 
    {
        SceneManager.LoadScene(numeroEscena);
    }
    public void Resumen()
    {
        GameObject gb = Instantiate(_playPrefab);

    }

    public void ExitBoton()
    {
        SceneManager.LoadScene("MENU INICIAL");
    }
}
