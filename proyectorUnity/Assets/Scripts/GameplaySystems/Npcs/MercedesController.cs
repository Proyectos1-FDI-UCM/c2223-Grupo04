using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MercedesController : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField]
    float minTimeForEating, maxTimeForEating;
    [SerializeField]
    float mercedesSpeed, tiempoEsperaComidaCancelada, tiempoStun;
    float timeForEating;
    float contadorStun;
    Transform transformPlanta;
    PlantaBehaviour planta;
    //Collider a activar y desactivar durante los distintos estados de mercedes
    Collider2D _collider2D;
    [SerializeField]
    MercheStates estado;
    enum MercheStates
    {
        Comiendo,
        Esperando,
        Desplazandose,
        Stuneada
    }
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        Esperar();
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
        else if (estado == MercheStates.Desplazandose)
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
                Esperar();
            }
        } else if (estado == MercheStates.Stuneada)
        {
            //falta tema de activar animación de estar estuneada
            contadorStun -= Time.deltaTime;
            if(contadorStun < 0)
            {
                FinDeStun();
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
            _collider2D.enabled = true;
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
        Esperar();
        GenerateEatTime();
    }

    /// <summary>
    /// Genera un tiempo para volver a comer una planta.
    /// </summary>
    private void GenerateEatTime()
    {
        timeForEating = Random.Range(minTimeForEating, maxTimeForEating);
    }
    
    public void Stunear()
    {
        _collider2D.enabled = false;
        contadorStun = tiempoStun;
        estado = MercheStates.Stuneada;
    }

    private void FinDeStun()
    {
        Esperar();
        GenerateEatTime();
    }

    private void Esperar()
    {
        _collider2D.enabled = false;
        estado = MercheStates.Esperando;
    }
}
