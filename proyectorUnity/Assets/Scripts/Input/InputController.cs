using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InputController : MonoBehaviour
{
    GameManager gameManager;
    MovementController movementController;
    InventoryController inventoryController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        //Obtiene el componente de movimiento del player
        movementController = gameManager.getPlayer().GetComponent<MovementController>();
        inventoryController = gameManager.getPlayer().GetComponent<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward);
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);

            if(hit.collider != null)
            {
                Debug.Log("Ha colaideado");
                GameObject objeto = hit.collider.gameObject;
                if(gameObject.GetComponent<Tool>() != null)
                {
                    Debug.Log("Si que funciona así, pedazo de cazurro");
                }
            }
        }
    }
}
