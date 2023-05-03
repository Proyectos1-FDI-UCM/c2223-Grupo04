using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Transform _casa;
    Animator _anim;
    Transform _myTransform;
    Color _transparent = new Color(255,255,255,0);
    Color _white = new Color(255,255,255,255);
    //SOUND
    CharlieSoundController _charlieSound;
    bool isSounding;

    public void GoHome() 
    { 
        _myTransform.position = _casa.position;
        GetComponent<SpriteRenderer>().color =_transparent;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _myTransform = transform;
    }

    private void Start()
    {
        _charlieSound = GetComponent<CharlieSoundController>();
        GetComponent<SpriteRenderer>().enabled = true;
        isSounding = false;
    }

    private void Update()
    {
        
        _anim.SetBool("Walk", Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f || Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f);
        if ((Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f || Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f) && !isSounding) 
        {
            isSounding = true;
            StartCoroutine(CharliePasos());
        }
    }
    public IEnumerator CharliePasos()
    {
        _charlieSound.CharlieCamina();
        yield return new WaitForSeconds(.2f);
        isSounding = false;
    }
}
