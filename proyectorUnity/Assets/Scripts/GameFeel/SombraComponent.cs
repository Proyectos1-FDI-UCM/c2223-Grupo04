using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SombraComponent : MonoBehaviour
{
    GameObject _shadow;
    SpriteRenderer _thisSpriteRenderer;
    SpriteRenderer _shadowSpriteRenderer;
    
    Color blackAlfa;

    // Start is called before the first frame update
    void Start()
    {
        blackAlfa = new Color(0,0,0,140) ;

        _shadow = new GameObject("Shadow", typeof(SpriteRenderer));
        _shadow.transform.parent = gameObject.transform;
        _shadowSpriteRenderer = _shadow.GetComponent<SpriteRenderer>();

        _thisSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        _shadowSpriteRenderer.sortingOrder = _thisSpriteRenderer.sortingOrder -1;
        _shadow.transform.position = transform.position + new Vector3(0.25f,-0.24f,0f);
        _shadow.transform.localScale = new Vector3(1,0.25f,1);
        
    }

    // Update is called once per frame
    void Update()
    {
        _shadowSpriteRenderer.sprite = _thisSpriteRenderer.sprite;
        blackAlfa = new Color(0,0,0,140) ;
        //print(blackAlfa);
        _shadowSpriteRenderer.color = blackAlfa;
    }
}
