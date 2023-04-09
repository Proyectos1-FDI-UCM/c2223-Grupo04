using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SombraComponentUI : MonoBehaviour
{
    GameObject _shadow;
    Image _thisImage;
    Image _shadowImage;
    
    Color blackAlfa;

    // Start is called before the first frame update
    void Start()
    {
        blackAlfa = Color.black;

        _shadow = new GameObject("Shadow", typeof(Image));
        _shadow.transform.parent = gameObject.transform.parent;
        _shadowImage = _shadow.GetComponent<Image>();

        _thisImage = gameObject.GetComponent<Image>();
        
        _shadow.transform.position = transform.position + new Vector3(0.075f,0.075f,0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        _shadowImage.sprite = _thisImage.sprite;
        blackAlfa.a = _thisImage.color.a;
        _shadowImage.color = blackAlfa;
    }
}
