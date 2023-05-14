using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerPeter : InputController
{
    [SerializeField]
    private LayerMask _layerMask;

    // Update is called once per frame
    override protected void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        if (_movible)
        {
            movementController.Move(_h, _v);
            _playerController.Animate(_v, _h);

        }

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
                    //Debug.Log("hit a tool");

                    GameObject objeto = hit.collider.gameObject;
                    if (objeto.GetComponent<Tool>() != null)
                    {
                        //print("la tool tiene tula");
                        inventoryController.TryPickUpTool(objeto, mousePos);
                    }


                }
                else
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);
                    if (hit)
                    {
                        //Debug.Log("hit not a tool");
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


        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance._state == GameManager.GameStates.GAME)
        {
            GameManager.Instance.Pause();
        }



    }
}
