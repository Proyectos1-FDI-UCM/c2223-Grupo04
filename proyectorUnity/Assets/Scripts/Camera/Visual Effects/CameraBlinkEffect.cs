using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBlinkEffect : MonoBehaviour
{
    bool _isFlicker;
    public Color startColor;
    public Color endColor;
    [Range(0, 10)]
    [SerializeField]
    float speed;

    Image imgComp;

    //public GameObject flash;

    private void Start()
    {
        _isFlicker = false;
        imgComp = GetComponent<Image>();

        startColor = Color.white;
        endColor = Color.white;
        startColor.a = 1f;
        endColor.a = 0f;

        flicker();
    } 

    private void Update()
    {
        if(_isFlicker) imgComp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
        if (imgComp.color.a <= 0.01f) _isFlicker = false;
    }

    public void flicker() 
    {
        _isFlicker = true;
    
    }

}

