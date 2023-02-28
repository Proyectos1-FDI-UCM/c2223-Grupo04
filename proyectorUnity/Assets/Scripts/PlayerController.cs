using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool _irACasa;
    [SerializeField] public Transform _casa;
    public InventoryController _inventoryController;
    /// <summary>
    /// Instancia del PlayerController
    /// </summary>
    public static PlayerController Instance { get; private set; }

    private void Start()
    {
        _inventoryController = GetComponent<InventoryController>();
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
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
