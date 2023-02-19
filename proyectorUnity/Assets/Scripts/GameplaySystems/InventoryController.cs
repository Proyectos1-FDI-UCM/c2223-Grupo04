using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private GameObject tool;
    [SerializeField]
    [Tooltip("Ditancia mínima para que Charlie pueda coger la herramienta")]
    private float distanciaMin;

    /* 
    * Charlie coge el objeto, si se cumplen los requisitos.
    * Se debe pasar por parámetro, el objeto a coger y la posición del ratón en el clic.
    */
    public void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {
        //TODO añadir la condición de que esté suficientemente cerca de Charlie.
        if(tool == null)
        {
            tool = toolObject;
            Debug.Log("Objeto recogido");
        }
    }
}
