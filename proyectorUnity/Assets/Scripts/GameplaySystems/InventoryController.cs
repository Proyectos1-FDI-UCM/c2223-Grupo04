using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private GameObject tool;
    [SerializeField]
    [Tooltip("Ditancia m�nima para que Charlie pueda coger la herramienta")]
    private float distanciaMin;

    /* 
    * Charlie coge el objeto, si se cumplen los requisitos.
    * Se debe pasar por par�metro, el objeto a coger y la posici�n del rat�n en el clic.
    */
    public void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {
        //TODO a�adir la condici�n de que est� suficientemente cerca de Charlie.
        if(tool == null)
        {
            tool = toolObject;
            Debug.Log("Objeto recogido");
        }
    }
}
