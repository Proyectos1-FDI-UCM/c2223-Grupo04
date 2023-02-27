using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool _irACasa;
    [SerializeField] public Transform _casa;
    /// <summary>
    /// Instancia del PlayerController
    /// </summary>
    public static PlayerController Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (_irACasa && (_casa.position - transform.position).magnitude > 0.5)
        {
            GetComponent<MovementController>().Stop();
            transform.position = Vector2.MoveTowards(transform.position, _casa.position, GetComponent<MovementController>()._speed * Time.deltaTime);
        }
        else _irACasa = false;
        
    }
}
