using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Semillita"))
        {
            Debug.Log("DestructorDestruyendo");
            collision.gameObject.transform.parent.GetComponent<PeterMechanic>().SeedDestroyed();
            Destroy(collision.gameObject);
        }
    }
}
