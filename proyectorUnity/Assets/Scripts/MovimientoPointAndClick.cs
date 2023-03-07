using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MovimientoPointAndClick : MonoBehaviour
{
    NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    private void Update()
    {
    }
    public void MoveTo(Vector2 position)
    {
        agente.SetDestination(position);
    }
}
