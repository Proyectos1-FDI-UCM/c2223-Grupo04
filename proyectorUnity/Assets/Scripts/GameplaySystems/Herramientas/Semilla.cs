using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semilla : Tool
{
    [SerializeField]
    private ScriptablePlant TipoDePlanta;

    [SerializeField]
    private GameObject _plantaPrefab;

    [SerializeField]
    private GameObject _semillaAnim;
    [SerializeField]
    private Sprite _semilla;

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        if (objetoClicado.GetComponent<SoilComponent>() != null && objetoClicado.GetComponent<SoilComponent>().IsEmpty())  //si es soil y no esta plantado
        {
            //Plantamos la planta
            GameObject semilla = GameObject.Instantiate(_semillaAnim, objetoClicado.transform);
            semilla.GetComponent<SpriteRenderer>().sprite = _semilla;
            objetoClicado.GetComponent<SoilComponent>().Plant(_plantaPrefab, TipoDePlanta);
            //eliminamos herramienta del inventario
            inventoryController.RemoveTool();
        }
    }

    public override void PickUpTool()
    { //que no de se desactive el render

    }

}
