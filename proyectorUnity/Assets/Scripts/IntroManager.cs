using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroScene()); // Llamamos a la corrutina.
    }
    IEnumerator IntroScene() // Corrutina para la intro.
    {
        
        
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(1); // Carag la escena del menu inicial.

    }
}
