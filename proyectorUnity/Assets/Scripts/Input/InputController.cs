using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InputController : MonoBehaviour
{
    MovementController movementController;
    InventoryController inventoryController;

    // Start is called before the first frame update
    void Start()
    {
        //Obtiene el componente de movimiento del player
        movementController = PlayerController.Instance.gameObject.GetComponent<MovementController>();
        inventoryController = PlayerController.Instance.gameObject.GetComponent<InventoryController>();
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
            Vector2 mousePos = Input.mousePosition;
            //impacto de rayo desde ubicación del ratón a punto del mundo.
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);

            //Debug.Log(mousePos.x);
            //Debug.Log(mousePos.y);

            //Sólo entra si ha impactado con algún collider
            if (hit)
            {
                Debug.Log("Ha colaideado");
                GameObject objeto = hit.collider.gameObject;



                if(objeto.GetComponent<Tool>() != null)
                {
                    Debug.Log("Ha colaideado con un objeto de tipo tool");
                    inventoryController.TryPickUpTool(objeto, mousePos);
                }
                else //En caso de no ser un tool
                {
                    //Efectua la acción de clic de la herramienta
                    inventoryController.ClickFunction(objeto, mousePos);
                }
            }
        }
    }
}
