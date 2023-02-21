using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semilla : Tool
{
    [SerializeField]
    private ScriptablePlant TipoDePlanta;

    [SerializeField]
    private GameObject _plantaPrefab;
    private PlantaBehaviour _thisPlantaBehaviour;

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        Debug.Log("EEEEEEEEEE");
        if (objetoClicado.GetComponent<SoilComponent>() != null && objetoClicado.GetComponent<SoilComponent>()._isPlanted == false)            //si es soil y no esta plantado
        {
            Debug.Log("AAAAAAAAAAAA");


           _thisPlantaBehaviour = Instantiate(_plantaPrefab, objetoClicado.transform.position, Quaternion.identity, objetoClicado.transform).GetComponent<PlantaBehaviour>();  //instanciamos una planta, cogemos su PlantaBehaviour y le asignamos el soil como parent

            _thisPlantaBehaviour.PlantaData = TipoDePlanta;                         //le pasamos los datos del scriptable Object

            _thisPlantaBehaviour._isSoilFertile = objetoClicado.GetComponent<SoilComponent>()._isFertile;     //le pasamos si el soil es fertil o no

            objetoClicado.GetComponent<SoilComponent>()._isPlanted = true;                                     //marcamos el suelo como plantado

            inventoryController.tool = null;                                                     //eliminamos herramienta
            Debug.Log(inventoryController.tool);


        }



    }

    public override void PickUpTool()
    { //que no de se desactive el render
    }

}
