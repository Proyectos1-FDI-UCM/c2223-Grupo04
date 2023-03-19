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

    //Indica si la herramienta ha sido cogida
    bool pickedUp;

    private void Start()
    {
        pickedUp = false;
    }

    //M�todo para cuando el objeto es cogido.
    public virtual void PickUpTool()
    {
        //El objeto se vuelve invisible al ser recogido
        gameObject.GetComponent<Renderer>().enabled = false;
        pickedUp = true;
    }

    public virtual void DropTool()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        pickedUp = false;
    }

    public virtual bool IsPickedUp()
    {
        return pickedUp;
    }

    /// <summary>
    /// La funci�n a realizar al hacer clic con una herramienta
    /// </summary>
    /// <param name="objetoClicado">El objeto clicado lol</param>
    /// <param name="inventoryController">El inventario de Charlie</param>
    public abstract void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController);
}
