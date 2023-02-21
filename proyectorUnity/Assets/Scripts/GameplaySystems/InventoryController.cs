using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public GameObject tool;
    [SerializeField]
    [Tooltip("Ditancia mínima para que Charlie pueda coger la herramienta")]
    private float distanciaMin;

    /* 
    * Charlie coge el objeto, si se cumplen los requisitos.
    * Se debe pasar por parámetro, el objeto a coger y la posición del ratón en el clic.
    */
    public void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {
        //Debug.Log(Vector2.Distance(gameObject.transform.position, toolObject.transform.position));

        //Se puede coger el objeto si el inventario no está ocupado y está suficientemente cerca
        if (tool == null && Vector2.Distance(gameObject.transform.position, toolObject.transform.position) < distanciaMin)
        {
            tool = toolObject;
            toolObject.GetComponent<Tool>().PickUpTool();
            Debug.Log("Objeto recogido");
        } else if (tool == toolObject && Vector2.Distance(gameObject.transform.position, toolObject.transform.position) < distanciaMin)
        {
            tool = null;
            toolObject.GetComponent<Tool>().DropTool();
            Debug.Log("Objeto soltado");

        }
    }

    public void ClickFunction(GameObject objetoClicado, Vector2 mousePos)
    {
        if (tool != null && Vector2.Distance(gameObject.transform.position, objetoClicado.transform.position) < distanciaMin)
        {
            tool.GetComponent<Tool>().OnClickFunction(objetoClicado, this);
        }
    }
}
