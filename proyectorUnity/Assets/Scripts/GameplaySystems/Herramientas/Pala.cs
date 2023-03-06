using Unity.VisualScripting;
using UnityEngine;

public class Pala : Tool
{
    [SerializeField]
    GameObject _palaAnim;

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.GetComponent<SoilComponent>() != null)
        {
            GameObject.Instantiate(_palaAnim, objetoClicado.transform);
            objetoClicado.GetComponent<SoilComponent>().RemovePlant();
        } else if(objetoClicado.GetComponent<ObstacleBehaviour>() != null)
        {
            GameObject.Instantiate(_palaAnim, objetoClicado.transform.parent);
            objetoClicado.GetComponent<ObstacleBehaviour>().RemoveObstacle();
        }

    }
}
