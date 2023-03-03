using Unity.VisualScripting;
using UnityEngine;

public class Pala : Tool
{

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.GetComponent<SoilComponent>() != null) {
            objetoClicado.GetComponent<SoilComponent>().RemovePlant();
        } else if(objetoClicado.GetComponent<ObstacleBehaviour>() != null)
            objetoClicado.GetComponent<ObstacleBehaviour>().RemoveObstacle();

    }
}
