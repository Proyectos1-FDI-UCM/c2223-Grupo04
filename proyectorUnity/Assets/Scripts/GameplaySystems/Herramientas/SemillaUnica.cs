using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemillaUnica : Semilla
{
    public override void PickUpTool()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
