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
    float _h;
    float _v;

    // Start is called before the first frame update
    void Start()
    {
        //Obtiene el componente de movimiento del player
        movementController = GameManager.Instance._player.GetComponent<MovementController>();
        inventoryController = GameManager.Instance._player.GetComponent<InventoryController>();

        if (GameManager.Instance._player.GetComponent<InventoryControllerTutorial>() != null)
            inventoryController = GameManager.Instance._player.GetComponent<InventoryControllerTutorial>();

    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        movementController.Move(_h, _v);
        /*
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
        }*/

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
                GameObject objeto = hit.collider.gameObject;



                if (objeto.GetComponent<Tool>() != null)
                {
                    inventoryController.TryPickUpTool(objeto, mousePos);
                }
                else if (LayerMask.LayerToName(objeto.layer) == "NPC") 
                {
                    objeto.GetComponent<DialogosInGame>().Bocadillo();
                }
                else //En caso de no ser un tool
                {
                    //Efectua la acción de clic de la herramienta
                    inventoryController.ClickFunction(objeto, mousePos);
                }
            }
        }

        
    }

    public void ChangeTutorialMode(GameObject toolObject)
    {
        inventoryController = GameManager.Instance._player.GetComponent<InventoryController>();
        inventoryController.PickUpTool(toolObject);

    }
}
