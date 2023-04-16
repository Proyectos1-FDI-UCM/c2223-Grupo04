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
            collision.gameObject.GetComponent<WaterParticulitas>().ActivaParticulitas(); //Activa las particulas de los objetos en el rio.
        }
    }
}
