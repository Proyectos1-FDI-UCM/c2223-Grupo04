using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class HiglightItem : MonoBehaviour
{
    Outline outline;

    [SerializeField]
    Color color;

    private void Start()
    {
        Outline outline = GetComponent<Outline>();
    }


    private void OnMouseEnter()
    {

    }

    private void OnMouseExit() 
    {
        outline.enabled= false;
    }

}
