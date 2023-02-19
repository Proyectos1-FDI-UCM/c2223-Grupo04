using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz a implementar en clases hijas (cada herramienta)
public interface ToolInterface {
    public void OnClickFunction();
}
public class Tool : MonoBehaviour
{
    /**
     * Al ser una clase abstracta, no se puede programar aqu�. Es como un plano que deben cumplir las clases hijas.
     * Todos los m�todos de Tool deben ser implementados por sus clases hijas.
     * 
     */

    //M�todo para cuando el objeto es cogido.
    public void PickUpTool()
    {
        //El objeto se vuelve invisible al ser recogido
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void DropTool()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
