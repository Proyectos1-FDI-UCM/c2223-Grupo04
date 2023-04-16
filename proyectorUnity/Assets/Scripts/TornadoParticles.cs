using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TornadoParticles : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    private void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
