using UnityEngine;

public class Pala : Tool
{

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.GetComponent<ObstacleBehaviour>() != null) {
            objetoClicado.GetComponent<ObstacleBehaviour>().RemoveObstacle();

        } else if (objetoClicado.GetComponent<PlantaBehaviour>() != null) {
            objetoClicado.GetComponent<PlantaBehaviour>().RemovePlant();
        }
    }
}
