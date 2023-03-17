using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercedesController : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField]
    float minTimeForEating, maxTimeForEating;
    [SerializeField]
    float mercedesSpeed, tiempoEsperaComidaCancelada;
    float timeForEating;
    Transform transformPlanta;
    PlantaBehaviour planta;
    //[SerializeField]
    MercheStates estado;
    enum MercheStates
    {
        Comiendo,
        Esperando,
        Desplazandose
    }
    void Start()
    {
        estado = MercheStates.Esperando;
        levelManager = GameManager.Instance._levelManager;
        GenerateEatTime();
    }

    void Update()
    {

        if (estado == MercheStates.Esperando)
        {
            timeForEating -= Time.deltaTime;
            if (timeForEating < 0)
                MoverAComer();
        }
        if (estado == MercheStates.Desplazandose)
        {
            if (planta != null)
            {
                Vector2 direccion = transform.position - transformPlanta.position;
                transform.position = Vector2.MoveTowards(transform.position, transformPlanta.position, mercedesSpeed * Time.deltaTime);
                if (direccion.magnitude < 0.5)
                    Comer();
            } else
            {
                timeForEating = tiempoEsperaComidaCancelada;
                estado = MercheStates.Esperando;
            }
        }
        
    }
    /// <summary>
    /// Método que "llama a comer" a merche, haciendo que comience a moverse hacia una planta para comersela.
    /// </summary>
    private void MoverAComer()
    {
        planta = levelManager.GetGrownPlant();
        if (planta != null)
        {
            transformPlanta = planta.transform;
            estado = MercheStates.Desplazandose;
        }
        else
        {
            GenerateEatTime();
        }

    }

    /// <summary>
    /// Las acciones a realizar cuando merche se come una planta.
    /// </summary>
    private void Comer()
    {
        planta.transform.parent.GetComponent<SoilComponent>().RemovePlant();
        estado = MercheStates.Esperando;
        GenerateEatTime();
    }

    /// <summary>
    /// Genera un tiempo para volver a comer una planta.
    /// </summary>
    private void GenerateEatTime()
    {
        timeForEating = Random.Range(minTimeForEating, maxTimeForEating);
    }


}
