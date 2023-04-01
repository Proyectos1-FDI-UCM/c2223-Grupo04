using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Transform _casa;
    Animator _anim;
    Transform _myTransform;
    [SerializeField]
    Color _transparent = new Color(255,255,255,0);
    [SerializeField]
    Color _white = new Color(255,255,255,255);

    public void GoHome() 
    { 
        _myTransform.position = _casa.position;
        GetComponent<SpriteRenderer>().color =_transparent;
    }

    public void SetVerticalAxis(float value) { _anim.SetFloat("Vertical", value); }

    public void SetHorizontalAxis(float value) { _anim.SetFloat("Horizontal", value); }

    public void GetOutHome()
    {
        _anim.SetTrigger("Casa");
        _myTransform.GetChild(0).GetComponent<SpriteRenderer>().color = _white;
        _myTransform.GetChild(1).GetComponent<SpriteRenderer>().color = _white;
        GameManager.Instance.OutHome(1.7f);
    }
    public void RestoreOIL(){
        GetComponent<SpriteRenderer>().color =_white;
        _myTransform.GetChild(0).GetComponent<SpriteRenderer>().color = _transparent;
        _myTransform.GetChild(1).GetComponent<SpriteRenderer>().color = _transparent;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        _anim = GetComponent<Animator>();
        _myTransform = transform;
        GoHome();
    }

    private void Update()
    {
        _anim.SetBool("Walk", Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f || Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f);
    }
}
