using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeterMechanic : MonoBehaviour
{
    public GameObject[] seeds; // Array de los elementos que puede lanzar Peter al r�o.
    float time = 0; // Contador de tiempo.
    [SerializeField] float _spawnTime; //Tiempo en el que la semilla spawnea.
    [SerializeField] Transform _seedSpawn; // Lugar donde aparecen las semillas lanzadas.
    Animator _anim;
    [SerializeField] int _maxSeeds;
    int seedsCount = 0;
    private void Start()
    {
        _anim = transform.GetChild(2).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seedsCount < _maxSeeds)
        {
            time += Time.deltaTime;
            if (time >= _spawnTime)
            {
                Instantiate(seeds[Random.Range(0, seeds.Length)], _seedSpawn.position, Quaternion.identity, transform);
                time = 0;
                seedsCount++;
                _anim.SetTrigger("Fly");
            }
        }
        
    }

    public void SeedDestroyed()
    {
        seedsCount--;
    }
}
