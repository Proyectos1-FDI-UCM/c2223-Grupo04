using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    /**
     * Clase abstracta, es como un plano para las clases hijas. No se puede instanciar.
     * Todos los métodos abstract de Tool deben ser implementados por sus clases hijas como override.
     * Los métodos virtual, ya tienen una programación "predeterminada". Pueden ser "sobrescritos" con override igualmente.
     */

    //Método para cuando el objeto es cogido.
    public virtual void PickUpTool()
    {
        //El objeto se vuelve invisible al ser recogido
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public virtual void DropTool()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    /// <summary>
    /// La función a realizar al hacer clic con una herramienta
    /// </summary>
    /// <param name="objetoClicado">El objeto clicado lol</param>
    /// <param name="inventoryController">El inventario de Charlie</param>
    public abstract void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController);
}
