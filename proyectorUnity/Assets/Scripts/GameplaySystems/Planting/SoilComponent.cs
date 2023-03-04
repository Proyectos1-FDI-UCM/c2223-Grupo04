using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilComponent : MonoBehaviour
{

    [SerializeField]
    [Tooltip("El tipo de soil, que determina la velocidad de crecimiento de las plantas")]
    private bool _isFertile;
    private bool _isEmpty;
    private LevelManager _levelManager;

    [SerializeField]
    private GameObject _childPrefab;
    private GameObject _myChild;
    private void Start()
    {
        _levelManager = GameManager.Instance._levelManager;
        if(_childPrefab != null)
        {
            Instanciar();
        }
        _isEmpty = true;
    }

    public void Instanciar()
    {
        _myChild = Instantiate(_childPrefab,transform.position, Quaternion.identity, transform);
    }
    /// <summary>
    /// Planta la planta que le pases en el soil.
    /// </summary>
    public void Plant(GameObject plantPrefab, ScriptablePlant tipoPlanta)
    {
        //instanciamos una planta, cogemos su PlantaBehaviour y le asignamos el soil como parent
        PlantaBehaviour plantBehaviour = Instantiate(plantPrefab, transform.position, Quaternion.identity, transform).GetComponent<PlantaBehaviour>();
        //La configuramos
        plantBehaviour.SetUpPlant(_isFertile, tipoPlanta);
        _isEmpty = false;
        _myChild = transform.GetChild(0).gameObject;
        _levelManager.AddPlant(_myChild.GetComponent<PlantaBehaviour>());
    }

    /// <summary>
    /// Llamado para quitar una planta del soil.
    /// </summary>
    /// 
    public void RemovePlant()
    {
        _isEmpty = true;
        _myChild.GetComponent<PlantaBehaviour>().RemovePlant();
    }

    public bool IsEmpty()
    { return _isEmpty; }

    public GameObject GetMyPLant() 
    { return _myChild; }
}
