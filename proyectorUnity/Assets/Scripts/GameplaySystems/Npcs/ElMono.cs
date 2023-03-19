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
    [SerializeField]
    List<GameObject> posiblesPosiciones;

    [SerializeField]
    List<GameObject> listaTools;

    [SerializeField]
    float minTiempoMover, maxTiempoMover, monoSpeed;
    
    
    float tiempoMover;
    GameObject miHerramienta;

    enum EstadosMichael
    {
        Esperando,
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
        if(estado == EstadosMichael.Esperando)
        {
            tiempoMover -= Time.deltaTime;
            if (tiempoMover < 0)
                IrPorHerramienta();
        }
        else if(estado == EstadosMichael.YendoAPorHerramienta)
        {
            //Si la herramienta no está cogida, se va moviendo hacia ella. En caso de ser cogida, escoge otra.
            if(!miHerramienta.GetComponent<Tool>().IsPickedUp())
            {
                Vector2 direccion = transform.position - miHerramienta.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, miHerramienta.transform.position, monoSpeed * Time.deltaTime);
                if (direccion.magnitude < 0.4)
                    CogerHerramienta();
            } else
            {
                EscogerNuevaHerramienta();
            }
        }
    }

    private void CogerHerramienta()
    {
        miHerramienta.GetComponent<Collider2D>().enabled = false;
        miHerramienta.transform.SetParent(transform);
        estado = EstadosMichael.MoviendoHerramienta;
    }

    private void SoltarHerramienta()
    {
        miHerramienta.GetComponent<Collider2D>().enabled = true;
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
