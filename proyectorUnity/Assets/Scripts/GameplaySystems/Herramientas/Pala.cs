using Unity.VisualScripting;
using UnityEngine;

public class Pala : Tool
{
    [SerializeField]
    GameObject _palaAnim;
    private GameObject _animation;

    public override void OnClickFunction(GameObject objetoClicado, InventoryController inventoryController)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.GetComponent<SoilComponent>() != null)
        {
            if (!objetoClicado.GetComponent<SoilComponent>().IsEmpty())
            {
                _animation = GameObject.Instantiate(_palaAnim, objetoClicado.transform.parent.gameObject.transform);
                _animation.GetComponent<Animator>().SetTrigger("Accionar");
            }
            objetoClicado.GetComponent<SoilComponent>().RemovePlant();
        } else if (objetoClicado.GetComponent<ObstacleBehaviour>() != null)
        {
            _animation = GameObject.Instantiate(_palaAnim, objetoClicado.transform.parent.gameObject.transform);
            _animation.GetComponent<Animator>().SetTrigger("Accionar");

            objetoClicado.GetComponent<ObstacleBehaviour>().RemoveObstacle();
        }else if (objetoClicado.tag == "Obstaculo") 
        {
            _animation = GameObject.Instantiate(_palaAnim, objetoClicado.transform.parent.gameObject.transform);
            _animation.GetComponent<Animator>().SetTrigger("Chocar");
        } 
        else if(objetoClicado.GetComponent<MercedesController>() != null)
        {
            objetoClicado.GetComponent<MercedesController>().Stunear();
            Debug.Log("mercedes stuneada");
        } 

    }
}
