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
     * 3. Una vez cogida la desplaza a una nueva ubicaci�n. (Moviendo herramienta)
     * 4. Vuelve a esperar.
     */
    [Tooltip("las posibles posiciones sobre las que maikel puede dejar una herramienta")]
    [SerializeField]
    List<GameObject> posiblesPosiciones;

    [Tooltip("las herramientas que Miguel pue pillar")]
    [SerializeField]
    List<GameObject> listaTools;

    [Tooltip("transform ubicaci�n inicial de michelle")]
    [SerializeField]
    GameObject casitaMikhael;

    [Tooltip("punto de origen de la liana de Miguel")]
    [SerializeField]
    Transform origenLiana;

    [SerializeField]
    float minTiempoMover, maxTiempoMover, monoSpeed;

    [SerializeField]
    Animator maikelAnim;

    float tiempoMover;
    GameObject miHerramienta;
    GameObject nuevaPosicion;

    LineRenderer lineRenderer;
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
        lineRenderer = GetComponent<LineRenderer>();
        estado = EstadosMichael.Esperando;
        GeneraTiempoMover();
        lineRenderer.SetPosition(1, origenLiana.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (estado == EstadosMichael.Esperando || estado == EstadosMichael.EsperandoYendoACasa)
        {
            maikelAnim.SetBool("Balancea", false);
            maikelAnim.gameObject.GetComponent<SpriteRenderer>().flipX = false;

            tiempoMover -= Time.deltaTime;
            if (tiempoMover < 0)
            {
                IrPorHerramienta();
                GeneraTiempoMover();
            }
            if (estado == EstadosMichael.EsperandoYendoACasa)
            {
                if (MoverHacia(casitaMikhael))
                {
                    lineRenderer.enabled = false;
                    estado = EstadosMichael.Esperando;
                }
            }
        }
        else if (estado == EstadosMichael.YendoAPorHerramienta)
        {
            //Si la herramienta no est� cogida, se va moviendo hacia ella. En caso de ser cogida, escoge otra.
            if (!miHerramienta.GetComponent<Tool>().IsPickedUp())
            {
                if (MoverHacia(miHerramienta))
                    CogerHerramienta();
            }
            else
            {
                EscogerNuevaHerramienta();
            }
        }
        else if (estado == EstadosMichael.MoviendoHerramienta)
        {
            if (MoverHacia(nuevaPosicion))
                SoltarHerramienta();
        }
    }

    private bool MoverHacia(GameObject objetivo)
    {
        maikelAnim.SetBool("Balancea", true);
        Vector2 direccion = transform.position - objetivo.transform.position;
        //gira el sprite segun la direccion
        if (direccion.x < 0) maikelAnim.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else maikelAnim.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        transform.position = Vector2.MoveTowards(transform.position, objetivo.transform.position, monoSpeed * Time.deltaTime);
        lineRenderer.SetPosition(0, transform.position);
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
        
        CambiarOrigenLiana(nuevaPosicion.transform.position);
    }

    private void SoltarHerramienta()
    {
        miHerramienta.GetComponent<Collider2D>().enabled = true;
        //La posici�n relativa al mundo de la herramienta al padre.
        Vector3 posicionNueva = transform.InverseTransformPoint(miHerramienta.transform.position);

        //Saca la herramienta del parent.
        miHerramienta.transform.SetParent(null);

        //Convierte la herramienta a su nueva posici�n a trav�s del padre.
        miHerramienta.transform.position = transform.TransformPoint(posicionNueva);


        //Una vez soltada la herramienta, volver a espera e ir a casa.
        estado = EstadosMichael.EsperandoYendoACasa;
        
        CambiarOrigenLiana(casitaMikhael.transform.position);
    }

    private void GeneraTiempoMover()
    {
        tiempoMover = Random.Range(minTiempoMover, maxTiempoMover);
    }

    private void IrPorHerramienta()
    {
        EscogerNuevaHerramienta();
        estado = EstadosMichael.YendoAPorHerramienta;
        CambiarOrigenLiana(miHerramienta.transform.position);
        lineRenderer.enabled = true;
    }

    private void EscogerNuevaHerramienta()
    {
        //Saca un objeto aleatorio de la lista de objetos tools.
        miHerramienta = listaTools[Random.Range(0, listaTools.Count)];
    }

    private void CambiarOrigenLiana(Vector2 finPos)
    {
        origenLiana.gameObject.GetComponent<LianaOrigen>().SetLianaOrigen(transform.position, nuevaPosicion.transform.position);
        lineRenderer.SetPosition(1, origenLiana.position);
    }
}
