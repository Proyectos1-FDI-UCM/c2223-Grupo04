using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MercedesController : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField]
    float minTimeForEating, maxTimeForEating, timeAfterEating;
    [SerializeField]
    float mercedesSpeed, tiempoEsperaComidaCancelada, tiempoStun;
    [SerializeField]
    GameObject casitaMercedes;
    float timeForEating;
    float elapsedTimeAfterEating;
    float contadorStun;
    Transform transformObjetivo;
    PlantaBehaviour planta;
    //Collider a activar y desactivar durante los distintos estados de mercedes
    Collider2D _collider2D;
    [SerializeField]
    MercheStates estado;
    Animator merchAnimator;
    SpriteRenderer mercheRenderer;
    //Sound
    MercedesSoundController _mercheSound;
    enum MercheStates
    {
        Comiendo,
        EsperandoEnCasa,
        DesplazandoseAComer,
        DesplazandoseACasa,
        Stuneada
    }
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        Esperar();
        levelManager = GameManager.Instance._levelManager;
        GenerateEatTime();
        merchAnimator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        mercheRenderer = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        _mercheSound = GetComponent<MercedesSoundController>();
    }

    void Update()
    {

        if (estado == MercheStates.EsperandoEnCasa)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false); //Desactiva las particulas de Mercedes enterrada.
            timeForEating -= Time.deltaTime;
            if (timeForEating < 0)
            {
                MoverAComer();
            }
        }
        else if (estado == MercheStates.Comiendo)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false); //Desactiva las particulas de Mercedes enterrada.
            elapsedTimeAfterEating -= Time.deltaTime;
            if (elapsedTimeAfterEating < 0)
            {
                MoverACasa();
            }
        }
        else if (estado == MercheStates.DesplazandoseACasa)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true); //Activa las particulas de Mercedes enterrada.
            if (MoverHacia(transformObjetivo))
            {
                Esperar();
                LlegarAUnSitio();
            }

        }
        else if (estado == MercheStates.DesplazandoseAComer)
        {
            if (planta != null)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true); //Activa las particulas de Mercedes enterrada.
                if (MoverHacia(transformObjetivo))
                {
                    Comer();
                }
            }
            else
            {
                timeForEating = tiempoEsperaComidaCancelada;
                Esperar();
            }
        }
        else if (estado == MercheStates.Stuneada)
        {
            //falta tema de activar animacion de estar estuneada
            contadorStun -= Time.deltaTime;
            if (contadorStun < 0)
            {
                FinDeStun();
            }
        }

    }

    private void MoverACasa()
    {
        _collider2D.enabled = true;
        transformObjetivo = casitaMercedes.transform;
        estado = MercheStates.DesplazandoseACasa;
        mercheRenderer.flipX = casitaMercedes.transform.position.x > transform.position.x;
        merchAnimator.SetBool("Move", true);
    }

    private bool MoverHacia(Transform objetivo)
    {
        Vector2 direccion = transform.position - objetivo.position;
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, mercedesSpeed * Time.deltaTime);
        return direccion.magnitude < 0.4;
    }

    /// <summary>
    /// Metodo que "llama a comer" a merche, haciendo que comience a moverse hacia una planta para comersela.
    /// </summary>
    private void MoverAComer()
    {
        planta = levelManager.GetGrownPlant();
        if (planta != null)
        {
            _collider2D.enabled = true;
            transformObjetivo = planta.transform;
            estado = MercheStates.DesplazandoseAComer;
            mercheRenderer.flipX = planta.transform.position.x > transform.position.x;
            merchAnimator.SetBool("Move", true);
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
        GenerateEatTime();
        LlegarAUnSitio();
        estado = MercheStates.Comiendo;
        _mercheSound.MercedesMastica(); //Sonido de comer de Mercedes
        //Establece el tiempo a esperar nada mas despues de comer
        elapsedTimeAfterEating = timeAfterEating;
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
        estado = MercheStates.EsperandoEnCasa;
    }

    private void LlegarAUnSitio()
    {
        merchAnimator.SetBool("Move", false);
    }
}
