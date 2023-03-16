using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    public Transform target; //Variable que determina el objeto a trackear
    [SerializeField]
    Vector3 offset; //Variable que determina el retraso del seguimiento de la cámara
    [SerializeField]
    float speed; //Variable que determina la velocidad del seguimiento de la cámara


    private void Awake()
    {
        gameObject.transform.parent = null;
    }
    private void Start()
    {
        target = GameManager.Instance._player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime); //Uso del método Lerp de Unity para suavizar el seguimiento

        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

    }
}
