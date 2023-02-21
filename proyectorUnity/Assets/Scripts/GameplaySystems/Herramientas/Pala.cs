using UnityEngine;

public class Pala : Tool
{

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.tag == "Obstaculo") {
            Destroy(objetoClicado);
        }
    }
}
