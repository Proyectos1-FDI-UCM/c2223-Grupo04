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
            print(collision.gameObject.GetComponent<Rigidbody2D>().velocity);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(_posFuerza * fuerza);

            print(collision.gameObject.GetComponent<Rigidbody2D>().velocity);
        }
    }
}
