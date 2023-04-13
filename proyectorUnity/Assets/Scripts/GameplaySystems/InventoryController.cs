using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    private GameObject _tool;
    [SerializeField]
    [Tooltip("Ditancia m�nima para que Charlie pueda coger la herramienta")]
    protected float _distanciaMin;
    [SerializeField] LayerMask _destructeable; // Solo en el nivel de Peter.
    [SerializeField]
    private int inventoryQty;


    private void Start()
    {
        inventoryQty = 0;
    }

    public int GetInventoryQty()
    {
        return inventoryQty;
    }

    /* 
    * Charlie coge el objeto, si se cumplen los requisitos.
    * Se debe pasar por par�metro, el objeto a coger y la posici�n del rat�n en el clic.
    */
    public virtual void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {
        //Debug.Log(Vector2.Distance(gameObject.transform.position, toolObject.transform.position));

        //Se puede coger el objeto si el inventario no est� ocupado y est� suficientemente cerca
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
        toolObject.GetComponent<Semilla>().PickUpTool();
        if (_tool == null)
        {
            _tool = toolObject;
            inventoryQty++;
            GameManager.Instance._uIManager.changeInventory(_tool);
            GameManager.Instance._uIManager.CantSem(inventoryQty);
        }
        //Comprueba si es el mismo tipo de semilla, por ejemplo zanahoria.
        else if(_tool.GetComponent<Semilla>().GetScriptablePlant().Equals(toolObject.GetComponent<Semilla>().GetScriptablePlant()))
        {
            if (inventoryQty < _tool.GetComponent<Semilla>().GetMaxQty())
            {
                inventoryQty++;
                GameManager.Instance._uIManager.CantSem(inventoryQty);
            }
            else
            {
                inventoryQty = 0;
                GameManager.Instance._uIManager.CantSem(inventoryQty);
                RemoveTool();
            }
        }
    }

    /// <summary>
    /// Comprueba si el objeto est� al alcance de Charlie. En caso afirmativo, realiza la acci�n de clic de la herramienta.
    /// </summary>
    /// <param name="objetoClicado">El objeto clicado xd</param>
    /// <param name="mousePos">La posici�n del rat�n en el momento del clic</param>
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
        GameManager.Instance._uIManager.CantSem(inventoryQty);
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