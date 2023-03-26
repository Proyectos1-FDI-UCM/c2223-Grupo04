using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElMono : MonoBehaviour
{
    /*
     * Mueve de lugar las distintas herramientas del nivel.
     * 
     * 1. Espera hasta el momento de empezar a mover una herramienta. (esperando)
     * 2. Se mueve a la herramienta y la coge. (YendoAPorHerramienta).
     * 3. Una vez cogida la desplaza a una nueva ubicación. (Moviendo herramienta)
     * 4. Vuelve a esperar.
     */
    [Tooltip("las posibles posiciones sobre las que maikel puede dejar una herramienta")]
    [SerializeField]
    List<GameObject> posiblesPosiciones;

    [Tooltip("las herramientas que Miguel pue pillar")]
    [SerializeField]
    List<GameObject> listaTools;

    [Tooltip("transform ubicación inicial de michelle")]
    [SerializeField]
    GameObject casitaMikhael;

    [SerializeField]
    float minTiempoMover, maxTiempoMover, monoSpeed;

    float tiempoMover;
    GameObject miHerramienta;
    GameObject nuevaPosicion;
    enum EstadosMichael
    {
        Esperando,
        EsperandoYendoACasa,
        YendoAPorHerramienta,
        MoviendoHerramienta
    }

    EstadosMichael estado;

    private void Start()
    {
       
        estado = EstadosMichael.Esperando;
        GeneraTiempoMover();
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == EstadosMichael.Esperando || estado == EstadosMichael.EsperandoYendoACasa)
        {
            tiempoMover -= Time.deltaTime;
            if (tiempoMover < 0)
            {
                IrPorHerramienta();
                GeneraTiempoMover();
            } 
            if (estado == EstadosMichael.EsperandoYendoACasa)
            {
                if(MoverHacia(casitaMikhael))
                {
                    estado = EstadosMichael.Esperando;
                }
            }
        }
        else if (estado == EstadosMichael.YendoAPorHerramienta)
        {
            //Si la herramienta no está cogida, se va moviendo hacia ella. En caso de ser cogida, escoge otra.
            if (!miHerramienta.GetComponent<Tool>().IsPickedUp())
            {
                if (MoverHacia(miHerramienta))
                    CogerHerramienta();
            }
            else
            {
                EscogerNuevaHerramienta();
            }
        } else if (estado == EstadosMichael.MoviendoHerramienta)
        {
            if (MoverHacia(nuevaPosicion))
                SoltarHerramienta();
        }
    }

    private bool MoverHacia(GameObject objetivo)
    {
        Vector2 direccion = transform.position - objetivo.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, objetivo.transform.position, monoSpeed * Time.deltaTime);
        return direccion.magnitude < 0.4;
    }

    private void CogerHerramienta()
    {
        EscogerNuevaPosition();
        miHerramienta.GetComponent<Collider2D>().enabled = false;
        miHerramienta.transform.SetParent(transform);
        estado = EstadosMichael.MoviendoHerramienta;
    }

    private void EscogerNuevaPosition()
    {
        do
            nuevaPosicion = posiblesPosiciones[Random.Range(0, posiblesPosiciones.Count)];
        while (nuevaPosicion.GetComponent<ToolLocation>().IsOcupied());
    }

    private void SoltarHerramienta()
    {
        miHerramienta.GetComponent<Collider2D>().enabled = true;
        //La posición relativa al mundo de la herramienta al padre.
        Vector3 posicionNueva = transform.InverseTransformPoint(miHerramienta.transform.position);
        
        //Saca todos los hijos del transform.
        transform.DetachChildren();
        //Convierte la herramienta a su nueva posición a través del padre.
        miHerramienta.transform.position = transform.TransformPoint(posicionNueva);

        //Una vez soltada la herramienta, volver a espera e ir a casa.
        estado = EstadosMichael.EsperandoYendoACasa;
    }

    private void GeneraTiempoMover()
    {
        tiempoMover = Random.Range(minTiempoMover, maxTiempoMover);
    }

    private void IrPorHerramienta()
    {
        EscogerNuevaHerramienta();
        estado = EstadosMichael.YendoAPorHerramienta;
    }

    private void EscogerNuevaHerramienta()
    {
        //Saca un objeto aleatorio de la lista de objetos tools.
        miHerramienta = listaTools[Random.Range(0, listaTools.Count)];
    }
}
