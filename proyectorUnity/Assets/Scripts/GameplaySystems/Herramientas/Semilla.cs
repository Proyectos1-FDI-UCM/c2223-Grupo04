using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semilla : Tool
{
    [SerializeField]
    private ScriptablePlant TipoDePlanta;

    [SerializeField]
    private GameObject _plantaPrefab;

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        if (objetoClicado.GetComponent<SoilComponent>() != null && !objetoClicado.GetComponent<SoilComponent>().IsPlanted())  //si es soil y no esta plantado
        {
            //Plantamos la planta
            objetoClicado.GetComponent<SoilComponent>().Plant(_plantaPrefab, TipoDePlanta);
            //eliminamos herramienta del inventario
            inventoryController.RemoveTool();

        }

    }

    public override void PickUpTool()
    { //que no de se desactive el render

    }

}
