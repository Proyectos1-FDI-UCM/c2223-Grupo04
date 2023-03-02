using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    private GameObject _tool;
    [SerializeField]
    [Tooltip("Ditancia mínima para que Charlie pueda coger la herramienta")]
    private float _distanciaMin;

    /* 
    * Charlie coge el objeto, si se cumplen los requisitos.
    * Se debe pasar por parámetro, el objeto a coger y la posición del ratón en el clic.
    */
    public void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {
        //Debug.Log(Vector2.Distance(gameObject.transform.position, toolObject.transform.position));

        //Se puede coger el objeto si el inventario no está ocupado y está suficientemente cerca
        if (_tool == null && Vector2.Distance(gameObject.transform.position, toolObject.transform.position) < _distanciaMin)
        {
            PickUpTool(toolObject);
            toolObject.GetComponent<Tool>().PickUpTool();
        } else if (_tool == toolObject && Vector2.Distance(gameObject.transform.position, toolObject.transform.position) < _distanciaMin)
        {
            RemoveTool();
            toolObject.GetComponent<Tool>().DropTool();
        }
    }

    public void ClickFunction(GameObject objetoClicado, Vector2 mousePos)
    {
        if (_tool != null && Vector2.Distance(gameObject.transform.position, objetoClicado.transform.position) < _distanciaMin)
        {
            _tool.GetComponent<Tool>().OnClickFunction(objetoClicado, this);
        }
    }

    public void PickUpTool(GameObject toolObject)
    {
        _tool = toolObject;
        GameManager.Instance._uIManager.changeInventory(_tool);
    }

    //Lo que pasa cuando sueltas una herramienta
    public void RemoveTool()
    {
        GameManager.Instance._uIManager.changeInventory(null);
        _tool = null;
    }
}
