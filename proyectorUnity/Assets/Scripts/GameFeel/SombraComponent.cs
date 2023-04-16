using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SombraComponent : MonoBehaviour
{
    [SerializeField]
    GameObject _npcGO;
    GameObject _shadow;
    GameObject _shadowParent;
    SpriteRenderer _thisSpriteRenderer;
    SpriteRenderer _shadowSpriteRenderer;
    
    Color blackAlfa;

    // Start is called before the first frame update
    void Start()
    {
        if (_npcGO == null) { _npcGO = gameObject; }
        //Creamos los objetos de la sombra y su padre
        _shadow = new GameObject("Shadow", typeof(SpriteRenderer));
        _shadowParent = new GameObject("ShadowParent");
        //Colocamos en la jerarquia los gameobjects
        _shadowParent.transform.parent = gameObject.transform;
        _shadow.transform.parent = _shadowParent.transform;
        //Cacheamos los sprite renderers
        _shadowSpriteRenderer = _shadow.GetComponent<SpriteRenderer>();
        _thisSpriteRenderer = _npcGO.GetComponent<SpriteRenderer>();

        //Cambiamos el order in layer de la sombra para que esté por debajo del sprite del jugador
        _shadowSpriteRenderer.sortingOrder = _thisSpriteRenderer.sortingOrder -1;
        //Cacheamos los transforms
        Transform shadowTr = _shadow.transform;
        Transform shadowParentTr = _shadowParent.transform;

        //Ajustando el transform de la sombra
        shadowTr.position = Vector3.zero;
        shadowTr.localScale = new Vector3(1,1,1);
        shadowTr.Rotate(new Vector3(0,0,-31));
        //Ajustando el transform del padre de la sombra
        shadowParentTr.position = transform.position + new Vector3(0.35f, -0.1f, 0f);
        shadowParentTr.localScale = new Vector3(1.4f, 0.7f, 0.7f);
        shadowParentTr.Rotate(new Vector3(0,0,17));
        
    }

    // Update is called once per frame
    void Update()
    {
        //Asignamos a la sombra el sprite del jugador a la sompra para que cambie igual que la animación
        _shadowSpriteRenderer.sprite = _thisSpriteRenderer.sprite;
        _shadowSpriteRenderer.flipX = _thisSpriteRenderer.flipX;

        //creamos un color temporal con la transparencia deseada y lo asignamos a la sombra
        Color tmp = new Color(0, 0, 0); ;
        if (_thisSpriteRenderer.color.a > 0) { tmp.a = 115; }
        else { tmp.a = 0; }

        _shadowSpriteRenderer.color = tmp;
        //print(_shadowSpriteRenderer.color);
        //print(_shadowSpriteRenderer.color.a);
    }
}
