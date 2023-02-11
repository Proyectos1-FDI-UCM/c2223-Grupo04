using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    GameManager gameManager;
    MovementController movementController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        //Obtiene el componente de movimiento del player
        movementController = gameManager.getPlayer().GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {   if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            movementController.Stop();
        else
        {
            if (Input.GetKey(KeyCode.W))
                movementController.Up();
            if (Input.GetKey(KeyCode.A))
                movementController.Left();
            if (Input.GetKey(KeyCode.S))
                movementController.Down();
            if (Input.GetKey(KeyCode.D))
                movementController.Right();
        }
    }
}
