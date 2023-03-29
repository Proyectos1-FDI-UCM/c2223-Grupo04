using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Transform _casa;
    Animator _anim;
    Transform _myTransform;
    [SerializeField]
    GameObject _radius;

    public void GoHome() 
    { 
        _myTransform.position = _casa.position;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SetVerticalAxis(float value) { _anim.SetFloat("Vertical", value); }

    public void SetHorizontalAxis(float value) { _anim.SetFloat("Horizontal", value); }

    public void GetOutHome()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        _anim.SetTrigger("Casa");
        GameManager.Instance.OutHome(1.75f);
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        _anim = GetComponent<Animator>();
        _myTransform = transform;
    }

    private void Update()
    {
        _anim.SetBool("Walk", Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f || Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f);
    }
}
