using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ToolLocation : MonoBehaviour
{
    [SerializeField]
    bool isOcupied;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entrada colision" + gameObject.name);
        if (CheckCollidingTool(collision.gameObject.GetComponent<Tool>()))
            isOcupied = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Salida colision" + gameObject.name);
        if(CheckCollidingTool(collision.gameObject.GetComponent<Tool>()))
            isOcupied = false;
    }

    private bool CheckCollidingTool(Tool tool)
    {
        return tool != null;
    }

    public bool IsOcupied()
    {
        return isOcupied;
    }
}
