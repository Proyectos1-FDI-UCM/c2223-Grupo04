using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercedesController : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField]
    float minTimeForEating, maxTimeForEating;
    float timeForEating;

    MercheStates estado;
    enum MercheStates
    {
        Comiendo,
        Esperando
    }
    void Start()
    {
        estado = MercheStates.Esperando;
        levelManager = GameManager.Instance._levelManager;
        GenerateEatTime();
    }

    void Update()
    {
        if(estado == MercheStates.Esperando)
            timeForEating -= Time.deltaTime;
        if(timeForEating < 0)
        {
            estado = MercheStates.Comiendo;
            Comer();
        }
    }

    private void Comer()
    {
        //Programar la animación a ejecutar mientras está comiendo. La animación tomará un tiempo.
        PlantaBehaviour planta = levelManager.GetGrownPlant();
        if (planta != null)
        {
            Transform transformPlanta = planta.transform;
            transform.position = transformPlanta.position;
            planta.RemovePlant();
            Debug.Log("A comer!");
        }
        GenerateEatTime();
        estado = MercheStates.Esperando;
    }

    private void GenerateEatTime()
    {
        timeForEating = Random.Range(minTimeForEating, maxTimeForEating);
    }
}
