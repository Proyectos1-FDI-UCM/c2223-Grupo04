using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxComponent : MonoBehaviour
{
    Transform _myTransform;
    Transform _cameraTransform;
    /// <summary>
    /// Velocidad de movimiento del paralaje;
    /// </summary>
    [SerializeField]
    float _movementVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.position = -_cameraTransform.position * _movementVelocity;
    }
}

