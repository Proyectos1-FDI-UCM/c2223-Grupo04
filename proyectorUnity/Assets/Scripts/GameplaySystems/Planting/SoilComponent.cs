using System;
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
    [Tooltip("Prefab a generar como hijo sobre este soil, por ejemplo un obstáculo removible")]
    private GameObject _childPrefab;
    private GameObject _myChild;
    private HiglightItem _highlight;

    private void Start()
    {
        _levelManager = GameManager.Instance._levelManager;
        _highlight = gameObject.GetComponent<HiglightItem>();

        if (_childPrefab != null)
        {
            Instanciar(_childPrefab);
            
        }else _isEmpty = true;
    }

    /// <summary>
    /// Convert the soil to a fertile one
    /// </summary>
    public void Fertilice()
    {
        _isFertile = true;

        //if there is a plant inside the soil, it gets fertiliced
        if (_myChild != null && _myChild.GetComponent<PlantaBehaviour>() != null) {_myChild.GetComponent<PlantaBehaviour>().SetFertil(_isFertile);}
    }

    /// <summary>
    /// Instancia _myChild como hijo a partir del tranform de este soil.
    /// </summary>
    public void Instanciar(GameObject childPrefab)
    {
        _myChild = Instantiate(childPrefab, transform.position, Quaternion.identity, transform);
        _isEmpty = false;
        _highlight.enabled = false;
    }

    /// <summary>
    /// Planta la planta que le pases en el soil.
    /// </summary>
    public void Plant(GameObject plantPrefab, ScriptablePlant tipoPlanta)
    {
        //instanciamos una planta, cogemos su PlantaBehaviour y le asignamos el soil como parent
        _myChild = Instantiate(plantPrefab, transform.position, Quaternion.identity, transform);
        PlantaBehaviour plantBehaviour = _myChild.GetComponent<PlantaBehaviour>();

        //La configuramos
        plantBehaviour.SetUpPlant(tipoPlanta);
        plantBehaviour.SetFertil(_isFertile);

        _isEmpty = false;
        _levelManager.AddPlant(plantBehaviour);
    }

    /// <summary>
    /// Comprueba si hay planta y llama a destruirla en caso de que haya.
    /// </summary>
    public void RemovePlant()
    {
        if(_myChild.GetComponent<PlantaBehaviour>() != null)
        {
            _isEmpty = true;
            _myChild.GetComponent<PlantaBehaviour>().RemovePlant();
        }
    }
    /// <summary>
    /// Si hay planta, riega.
    /// </summary>
    internal void RegarPlant()
    {
        if (!_isEmpty)
        {
            _myChild.GetComponent<PlantaBehaviour>().GetWatered();
        }
    }
    public bool HasPlant()
    {
        return (_myChild != null && _myChild.GetComponent<PlantaBehaviour>() != null);
    }
    public bool IsEmpty()
    { return _isEmpty; }

    public GameObject GetMyPLant() 
    { return _myChild; }

    public void SetIsEmpty(bool isEmpty)
    {
        _isEmpty = isEmpty;
    }

    public void RemoveObstacle()
    {
        _isEmpty = true;
        _highlight.enabled = true;

    }

   
}
