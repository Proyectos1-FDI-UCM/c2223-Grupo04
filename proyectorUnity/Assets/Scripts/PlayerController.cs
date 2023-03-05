using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool _irACasa;
    [SerializeField] public Transform _casa;
    Animator _anim;
    Rigidbody2D _rb;
    
    /// <summary>
    /// Instancia del PlayerController
    /// </summary>
    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        _anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        _anim.SetBool("Walk", Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f || Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f);

        if (_irACasa) //(&& _casa.position - transform.position).magnitude > 0.5)
        {
            GetComponent<MovementController>().Stop();
            //transform.position = Vector2.MoveTowards(transform.position, _casa.position, GetComponent<MovementController>()._speed * Time.deltaTime);
            transform.position = _casa.position;
            _irACasa = false;
        }
        else _irACasa = false;
        
    }
}
