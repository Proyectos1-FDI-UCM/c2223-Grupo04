using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regadera : Tool
{
    [SerializeField]
    GameObject _regaderaAnim;

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.GetComponent<SoilComponent>() != null)
        {
            objetoClicado.GetComponent<SoilComponent>().RegarPlant();
            if (!objetoClicado.GetComponent<SoilComponent>().IsEmpty())
            {
                //print("AAAAAAAAAAAAAAAA");
                GameObject.Instantiate(_regaderaAnim, objetoClicado.transform);
            }
        }
    }
}
