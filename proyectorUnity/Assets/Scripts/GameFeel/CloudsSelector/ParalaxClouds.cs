using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxClouds : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _duration;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
        Destroy(gameObject, _duration);
    }
}
