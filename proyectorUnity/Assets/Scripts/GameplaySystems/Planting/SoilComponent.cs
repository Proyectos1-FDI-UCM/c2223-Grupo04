using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilComponent : MonoBehaviour
{

    [SerializeField]
    [Tooltip("El tipo de soil, que determina la velocidad de crecimiento de las plantas")]
    private bool _isFertile;
    private bool _isPlanted;
    private LevelManager _levelManager;

    private GameObject _myPlant;
    private void Start()
    {
        _levelManager = GameManager.Instance._levelManager;
        _isPlanted = false;
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
        _isPlanted = true;
        _myPlant = transform.GetChild(0).gameObject;
        _levelManager.AddPlant(_myPlant.GetComponent<PlantaBehaviour>());
    }

    /// <summary>
    /// Llamado para quitar una planta del soil.
    /// </summary>
    public void RemovePlant()
    {
        _isPlanted = false;
        _myPlant.GetComponent<PlantaBehaviour>().RemovePlant();
    }

    public bool IsPlanted()
    { return _isPlanted; }

    public GameObject GetMyPLant() 
    { return _myPlant; }
}
