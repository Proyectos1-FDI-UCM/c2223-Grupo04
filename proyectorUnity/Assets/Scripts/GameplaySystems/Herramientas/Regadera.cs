using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regadera : Tool
{
    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.GetComponent<SoilComponent>() != null && objetoClicado.GetComponent<SoilComponent>().IsEmpty())
        {
            objetoClicado.transform.GetChild(0).GetComponent<PlantaBehaviour>().GetWatered();

        }
    }
}
