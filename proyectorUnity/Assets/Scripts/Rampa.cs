using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rampa : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
