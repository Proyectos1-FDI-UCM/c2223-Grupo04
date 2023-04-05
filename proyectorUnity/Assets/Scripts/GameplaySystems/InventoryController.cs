using System;
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
    [SerializeField] LayerMask _destructeable; // Solo en el nivel de Peter.
    private int inventoryQty;


    private void Start()
    {
        inventoryQty = 0;
    }

    /* 
    * Charlie coge el objeto, si se cumplen los requisitos.
    * Se debe pasar por parámetro, el objeto a coger y la posición del ratón en el clic.
    */
    public virtual void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {
        //Debug.Log(Vector2.Distance(gameObject.transform.position, toolObject.transform.position));

        //Se puede coger el objeto si el inventario no está ocupado y está suficientemente cerca
        if (Vector2.Distance(gameObject.transform.position, toolObject.transform.position) < _distanciaMin)
        {
            if (toolObject.GetComponent<Semilla>() != null)
            {
                PickUpSemilla(toolObject);
            }
            else if (_tool == null)
            {
                PickUpTool(toolObject);
                toolObject.GetComponent<Tool>().PickUpTool();
            }
            else if (_tool == toolObject)
            {
                RemoveTool();
                toolObject.GetComponent<Tool>().DropTool();
            }
        }
    }

    private void PickUpSemilla(GameObject toolObject)
    {
        if (_tool == null)
        {
            _tool = toolObject;
            GameManager.Instance._uIManager.changeInventory(_tool);
            inventoryQty++;
        }
        //Comprueba si es el mismo tipo de semilla, por ejemplo zanahoria.
        else if(_tool.GetComponent<Semilla>().GetScriptablePlant().Equals(toolObject.GetComponent<Semilla>().GetScriptablePlant()))
        {
            if (inventoryQty < _tool.GetComponent<Semilla>().GetMaxQty())
            {
                inventoryQty++;
            }
            else
            {
                inventoryQty = 0;
                RemoveTool();
            }
        }
    }

    /// <summary>
    /// Comprueba si el objeto está al alcance de Charlie. En caso afirmativo, realiza la acción de clic de la herramienta.
    /// </summary>
    /// <param name="objetoClicado">El objeto clicado xd</param>
    /// <param name="mousePos">La posición del ratón en el momento del clic</param>
    public virtual void ClickFunction(GameObject objetoClicado, Vector2 mousePos)
    {
        if (_tool != null && Vector2.Distance(gameObject.transform.position, objetoClicado.transform.position) < _distanciaMin)
        {
            _tool.GetComponent<Tool>().OnClickFunction(objetoClicado, this);
        }
    }

    public void UsarSemilla()
    {
        inventoryQty--;
        if (inventoryQty <= 0) { 
            RemoveTool();
        }
    }

    /// <summary>
    /// Guarda la herramienta en el inventario.
    /// </summary>
    /// <param name="toolObject">La herramienta a guardar</param>
    public void PickUpTool(GameObject toolObject)
    {
        _tool = toolObject;
        GameManager.Instance._uIManager.changeInventory(_tool);
    }

    /// <summary>
    /// Quita la herramienta que haya en el inventario.
    /// </summary>
    public void RemoveTool()
    {
        GameManager.Instance._uIManager.changeInventory(null);
        _tool = null;
    }

    public GameObject GetTool()
    {
        return _tool;
    }
}