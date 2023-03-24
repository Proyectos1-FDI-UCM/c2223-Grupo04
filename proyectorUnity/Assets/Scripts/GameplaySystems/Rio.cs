using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rio : MonoBehaviour
{
    [SerializeField]
    Vector2 _posFuerza;
    [SerializeField]
    float fuerza;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(_posFuerza * fuerza);
            collision.gameObject.GetComponent<WaterParticulitas>().ActivaParticulitas(); //Activa las part�culas de los objetos en el r�o.
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<WaterParticulitas>().DesactivaParticulitas(); //Desactiva las part�culas de los objetos en el r�o.
    }
}
