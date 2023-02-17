using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target; //Variable que determina el objeto a trackear
    public Vector3 offset; //Variable que determina el retraso del seguimiento de la c�mara
    public float speed; //Variable que determina la velocidad del seguimiento de la c�mara



    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime); //Uso del m�todo Lerp de Unity para suavizar el seguimiento

    }
}
