using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Transform _casa;
    Animator _anim;
    float _animTime;
    bool _stopAnim;
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
        _anim.SetTrigger("Casa");
        GetComponent<SpriteRenderer>().enabled = true;
        _animTime = _anim.GetCurrentAnimatorStateInfo(0).length;
        _stopAnim = true;
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
        
        if (_animTime >= 0 && !_stopAnim) { _animTime -= Time.deltaTime;}
        else if(_stopAnim) 
        {
            GameManager.Instance._inputController.MoveOrNot(true);
            _stopAnim = false; 
        }
    }
}
