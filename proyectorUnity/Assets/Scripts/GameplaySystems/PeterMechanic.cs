using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PeterMechanic : MonoBehaviour
{
    public GameObject[] semillas; // Array de los elementos que puede lanzar Peter al río.
    float time = 0; // Tiempo.
    [SerializeField] Transform _semillaSpawn; // Lugar donde aparecen las semillas lanzadas.

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2) 
        {
            Instantiate(semillas[Random.Range(0, semillas.Length)], _semillaSpawn);
            time = 0;
        }
    }
}
