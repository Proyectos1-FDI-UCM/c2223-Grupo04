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
            if (!objetoClicado.GetComponent<SoilComponent>()._isEmpty)
            {
                GameObject.Instantiate(_palaAnim, objetoClicado.transform);
            }
            objetoClicado.GetComponent<SoilComponent>().RemovePlant();
        } else if(objetoClicado.GetComponent<ObstacleBehaviour>() != null)
        {
            GameObject.Instantiate(_palaAnim, objetoClicado.transform);
            objetoClicado.GetComponent<ObstacleBehaviour>().RemoveObstacle(.75f);
        }

    }
}
