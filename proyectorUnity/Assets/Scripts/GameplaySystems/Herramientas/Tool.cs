using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    /**
     * Al ser una clase abstracta, no se puede programar aquí. Es como un plano que deben cumplir las clases hijas.
     * Todos los métodos de Tool deben ser implementados por sus clases hijas.
     * 
     */
    public abstract void RightClickFunction();
}
