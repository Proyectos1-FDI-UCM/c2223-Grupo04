using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SombraComponentUI : MonoBehaviour
{
    Image _thisImage;
    [SerializeField]
    Image _shadowImage;

    private void Start()
    {
        UpdateSadow();
    }
    // Start is called before the first frame update
    public void UpdateSadow()
    {
        _thisImage = gameObject.GetComponent<Image>();
        _shadowImage.overrideSprite = _thisImage.sprite;
    }
}
