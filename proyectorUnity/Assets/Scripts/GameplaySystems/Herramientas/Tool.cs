using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    /**
     * Clase abstracta, es como un plano para las clases hijas. No se puede instanciar.
     * Todos los m�todos abstract de Tool deben ser implementados por sus clases hijas como override.
     * Los m�todos virtual, ya tienen una programaci�n "predeterminada". Pueden ser "sobrescritos" con override igualmente.
     */

    //M�todo para cuando el objeto es cogido.
    public virtual void PickUpTool()
    {
        //El objeto se vuelve invisible al ser recogido
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public virtual void DropTool()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    public abstract void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController);
}
