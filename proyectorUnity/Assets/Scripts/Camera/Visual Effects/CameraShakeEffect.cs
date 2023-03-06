using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeEffect : MonoBehaviour
{
    private void Start()
    {
        mainCamera = Camera.main;
        ShakeYourButty();
    }

    Vector3 cameraIniPos;
    public float temblorMagnitude = 0.075f;
    public Camera mainCamera;

    public void ShakeYourButty() 
    {

        cameraIniPos = mainCamera.transform.position;
        InvokeRepeating("StarthakingYourButty", 0f, 0.005f);
        //Invoke("StopShakingYourButty", tiempoTemblor);

    }

    void StarthakingYourButty() 
    {
        float temblorCamaraOffsetX = Random.value * temblorMagnitude *2 - temblorMagnitude;
        float temblorCamaraOffsetY = Random.value * temblorMagnitude *2 - temblorMagnitude;
        Vector3 camaraIntermediaPos = mainCamera.transform.position;
        camaraIntermediaPos.x += temblorCamaraOffsetX;
        camaraIntermediaPos.y += temblorCamaraOffsetY;
        mainCamera.transform.position = camaraIntermediaPos;

    }/*

    void StopdShakingYourButty() 
    {

        CancelInvoke("StarthakingYourButty");
        mainCamera.transform.position = cameraIniPos;
        
    }*/
}
