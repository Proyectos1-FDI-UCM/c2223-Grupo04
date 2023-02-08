using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    GameManager _gameManager;
    MovementController _movementController;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        //Obtiene el componente de movimiento del player
        _movementController = _gameManager.getPlayer().GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.W))
            _movementController.Up();
        if (Input.GetKey(KeyCode.A))
            _movementController.Left();
        if (Input.GetKey(KeyCode.S))
            _movementController.Down();
        if (Input.GetKey(KeyCode.D))
            _movementController.Right();
    }
}
