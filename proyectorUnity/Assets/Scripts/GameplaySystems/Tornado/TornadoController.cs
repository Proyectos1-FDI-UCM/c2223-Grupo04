using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static GameManager;

public class TornadoController : MonoBehaviour
{
    /// <summary>
    /// GameObject padre con los puntos por donde pasar� el tornado
    /// </summary>
    [SerializeField]
    public GameObject _tornadoPositions;
    /// <summary>
    /// ID del punto al que ir� el tornado
    /// </summary>
    [SerializeField]
    int id = 0;
    /// <summary>
    /// Velocidad del tornado
    /// </summary>
    [SerializeField]
    float _tornadoSpeed;
    /// <summary>
    /// Posici�n inicial del tornado
    /// </summary>
    Vector3 _startpos;

    private void Start()
    {
        _startpos = transform.position; //Guarda la posici�n inicial del tornado, ya que depende de cada nivel
        GameManager.Instance.ChangeState(GameStates.TORNADO); //llama para cambiar el estado a TORNADO
    }

    private void Update()
    {
        if (id < _tornadoPositions.transform.childCount)//Ha pasado el tornado por todos los puntos?
        {
            //almacena la direcci�n sin normalizar entre el inicio y el fin del movimiento
            Vector2 dir = transform.position - _tornadoPositions.transform.GetChild(id).transform.position;
            //Mueve el tornado
            transform.position = Vector2.MoveTowards(transform.position, _tornadoPositions.transform.GetChild(id).transform.position, _tornadoSpeed * Time.deltaTime);

            if (dir.magnitude < 0.5f)//Pasa al siguiente punto del movimiento
            {
                id++;
            }
        }
        else if((transform.position-_startpos).magnitude > 0.5f) //El tornado se destruye al llegar al �ltimo punto
        {
            Destroy(gameObject);
            SmoothCameraFollow.Instance.target = PlayerController.Instance.transform;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<SoilComponent>().IsEmpty())
        {
            collision.GetComponent<SoilComponent>().RemovePlant();
        }
    }

    private void OnDestroy()
    {
        Destroy(_tornadoPositions);
        GameManager.Instance.ChangeState(GameStates.GAME); //llama para cambiar el estado a GAME

    }
}
