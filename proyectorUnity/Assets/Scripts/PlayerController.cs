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

    public void GoHome(){_myTransform.position = _casa.position;}

    public void SetVerticalAxis(float value){_anim.SetFloat("Vertical", value);}

    public void SetHorizontalAxis(float value){ _anim.SetFloat("Horizontal", value); }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _myTransform = transform;

    }

    public void DrawCircle(float radius)
    {
        _radius.transform.localScale = new Vector3(radius, radius, 0);
    }

    private void Update()
    {
        _anim.SetBool("Walk", Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f || Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f);               
    }
}
