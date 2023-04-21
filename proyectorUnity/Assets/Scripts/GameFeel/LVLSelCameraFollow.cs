using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLSelCameraFollow : MonoBehaviour
{
    private Transform _myTransform;
    private Vector3 _mousePos;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Input.mousePosition;
        print(_mousePos);
        if ((_mousePos.x - (Camera.main.pixelWidth / 2)) <-1 || (_mousePos.x - (Camera.main.pixelWidth / 2)) > 1)
        {

        } 
        //_myTransform.x = 
    }
}
