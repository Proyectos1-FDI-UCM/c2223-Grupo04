using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private MovementController movementController;
    [SerializeField]
    private InventoryController inventoryController;
    private float _h;
    private float _v;
    [SerializeField]
    private bool _movible;
    [SerializeField]
    private LayerMask _layerMask;

    public void MoveOrNot(bool mov)
    {
        _movible = mov;
    }

    // Start is called before the first frame update
    void Start()
    {

        //Obtiene el componente de movimiento del player
        movementController = GameManager.Instance._player.GetComponent<MovementController>();
        

        _movible = false;

        if (GameManager.Instance._player.GetComponent<InventoryControllerTutorial>() != null)
            inventoryController = GameManager.Instance._player.GetComponent<InventoryControllerTutorial>();
        else if (GameManager.Instance._player.GetComponent<InventoryControllerRio>() != null)
            inventoryController = GameManager.Instance._player.GetComponent<InventoryControllerRio>();
        else
            inventoryController = GameManager.Instance._player.GetComponent<InventoryController>();


    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        if (_movible) { movementController.Move(_h, _v); }

        GameManager.Instance._player.GetComponent<PlayerController>().SetHorizontalAxis(_h);
        GameManager.Instance._player.GetComponent<PlayerController>().SetVerticalAxis(_v);


        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.Play(); //pasa al estado game

            if (_movible)
            {
                Vector2 mousePos = Input.mousePosition;
                //impacto de rayo desde ubicacion del raton a punto del mundo.
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero, 0, _layerMask);

                //Solo entra si ha impactado con algun collider
                if (hit)
                {
                    Debug.Log("hit a tool");

                    GameObject objeto = hit.collider.gameObject;
                    if (objeto.GetComponent<Tool>() != null)
                    {
                        print("la tool tiene tula");
                        inventoryController.TryPickUpTool(objeto, mousePos);
                    }
                    
                    
                }
                else
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);
                    if(hit) 
                    { 
                        Debug.Log("hit not a tool");
                        GameObject objeto = hit.collider.gameObject;

                        if (LayerMask.LayerToName(objeto.layer) == "NPC")
                        {
                            objeto.GetComponent<DialogosInGame>().Bocadillo();
                        }
                        else 
                        {
                            //Efectua la acci�n de clic de la herramienta
                            inventoryController.ClickFunction(objeto, mousePos);
                        }

                    }

                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape) &&  GameManager.Instance._state == GameManager.GameStates.GAME)
        {
            GameManager.Instance.Pause();
        }
    }

    public void ChangeTutorialMode(GameObject toolObject)
    {
        inventoryController = GameManager.Instance._player.GetComponent<InventoryController>();
        inventoryController.PickUpTool(toolObject);

    }
}
