using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElMono : MonoBehaviour
{
    /*
     * Mueve de lugar las distintas herramientas del nivel.
     * 
     * 1. Espera hasta el momento de empezar a mover una herramienta. (esperando)
     * 2. Se mueve a la herramienta y la coge. (YendoAPorHerramienta).
     * 3. Una vez cogida la desplaza a una nueva ubicación. (Moviendo herramienta)
     * 4. Vuelve a esperar.
     */
    [SerializeField]
    List<Transform> posiblesPosiciones;

    [SerializeField]
    List<GameObject> listaTools;

    enum EstadosMichael
    {
        Esperando,
        YendoAPorHerramienta,
        MoviendoHerramienta
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
