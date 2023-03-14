using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    
    /*public void CambiaEscena1(string nombreEscena) 
    {
        SceneManager.LoadScene(nombreEscena);
    }*/
    public void CambiaEscena2(int numeroEscena) 
    {
        SceneManager.LoadScene(numeroEscena);
    }
}
