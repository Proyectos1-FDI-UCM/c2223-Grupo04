using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PeterMechanic : MonoBehaviour
{
    public GameObject[] semillas; // Array de los elementos que puede lanzar Peter al río.
    [SerializeField] float time; // Tiempo entre cada elemento lanzado por Peter.
    [SerializeField] Transform _semillaSpawn; // Lugar donde aparecen las semillas lanzadas.
    [SerializeField] GameObject _semillaDestructor; //Lugar donde se destruyen las semillas

    // Update is called once per frame
    void Update()
    {
        //transform.position = _semillaSpawn.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ColisiónUwU");
        if (collision.gameObject.transform.position.x < _semillaDestructor.gameObject.transform.position.x) 
        {
            Destroy(collision.gameObject);
        }
    }
}
