using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    [SerializeField] Vector2 _posFuerza;
    [SerializeField] float fuerza;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(_posFuerza * fuerza);
            GameManager.Instance._inputController.MoveOrNot(false); // Hacer que el jugador no se pueda mover al caer por la rampa.
            Debug.Log("InputDesactivadoEnRampa");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance._inputController.MoveOrNot(true); // Hacer que el jugador se pueda volver a mover al salir de la rampa.
        Debug.Log("InputActivadoEnRampa");
    }
}
