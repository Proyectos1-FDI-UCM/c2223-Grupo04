using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PeterMechanic : MonoBehaviour
{
    public GameObject[] seeds; // Array de los elementos que puede lanzar Peter al río.
    float time = 0; // Contador de tiempo.
    [SerializeField] float _spawnTime; //Tiempo en el que la semilla spawnea.
    [SerializeField] Transform _seedSpawn; // Lugar donde aparecen las semillas lanzadas.

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= _spawnTime) 
        {
            Instantiate(seeds[Random.Range(0, seeds.Length)], _seedSpawn);
            time = 0;
        }
    }
}
