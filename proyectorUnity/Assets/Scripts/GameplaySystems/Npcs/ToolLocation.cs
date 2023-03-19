using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ToolLocation : MonoBehaviour
{
    [SerializeField]
    bool isOcupied;

    private void Start()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward); 
        CheckCollidingTool(hit.collider.GetComponent<Tool>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckCollidingTool(collision.collider.GetComponent<Tool>());
    }

    private void OnCollisionExit(Collision collision)
    {
        CheckCollidingTool(collision.collider.GetComponent<Tool>());
    }

    private void CheckCollidingTool(Tool tool)
    {
        isOcupied = tool != null;
    }

    public bool IsOcupied()
    {
        return isOcupied;
    }
}
