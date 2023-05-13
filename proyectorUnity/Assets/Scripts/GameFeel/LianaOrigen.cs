using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianaOrigen : MonoBehaviour
{
    private Transform _myTransform;
    private void Start()
    {
        _myTransform = transform;
    }    
    public void SetLianaOrigen(Vector2 orignPos, Vector2 finPos)
    {
        Vector2 lianaOrgPos = transform.position;
        lianaOrgPos.x = (orignPos.x +  finPos.x)/2;
        _myTransform.position = lianaOrgPos;
    }
}
