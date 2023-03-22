using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PeterMechanic : MonoBehaviour
{
    [SerializeField]
    float time;
    [SerializeField]
    Transform _semillaSpawn;
    [SerializeField]
    GameObject _semillaDestructor;

    // Update is called once per frame
    void Update()
    {
        transform.position = _semillaSpawn.position;

     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject); 
    }
}
