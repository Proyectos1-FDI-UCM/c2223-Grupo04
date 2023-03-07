using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PruebaInputController : MonoBehaviour
{
    MovimientoPointAndClick movementController;
    InventoryController inventoryController;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        //Obtiene el componente de movimiento del player
        movementController = PlayerController.Instance.gameObject.GetComponent<MovimientoPointAndClick>();
        inventoryController = PlayerController.Instance.gameObject.GetComponent<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {

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

                movementController.MoveTo(hit.point);


                if(objeto.GetComponent<Tool>() != null)
                {
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
