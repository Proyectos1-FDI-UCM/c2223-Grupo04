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
        if (objetoClicado.GetComponent<SoilComponent>() != null && objetoClicado.GetComponent<SoilComponent>()._isPlanted == false)  //si es soil y no esta plantado
        {
            //instanciamos una planta, cogemos su PlantaBehaviour y le asignamos el soil como parent
            _thisPlantaBehaviour = Instantiate(_plantaPrefab, objetoClicado.transform.position, Quaternion.identity, objetoClicado.transform).GetComponent<PlantaBehaviour>();
            //le pasamos los datos del scriptable Object
            _thisPlantaBehaviour.PlantaData = TipoDePlanta;
            //le pasamos si el soil es fertil o no
            _thisPlantaBehaviour._isSoilFertile = objetoClicado.GetComponent<SoilComponent>()._isFertile;
            //marcamos el suelo como plantado
            objetoClicado.GetComponent<SoilComponent>()._isPlanted = true;
            //eliminamos herramienta
            inventoryController.RemoveTool();

        }



    }

    public override void PickUpTool()
    { //que no de se desactive el render

    }

}
