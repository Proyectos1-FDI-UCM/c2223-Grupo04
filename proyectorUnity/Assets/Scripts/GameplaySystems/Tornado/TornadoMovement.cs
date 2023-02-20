using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    /// <summary>
    /// GameObject padre con los puntos por donde pasará el tornado
    /// </summary>
    [SerializeField]
    public GameObject _tornadoPositions;
    /// <summary>
    /// ID del punto al que irá el tornado
    /// </summary>
    [SerializeField]
    int id = 0;
    /// <summary>
    /// Velocidad del tornado
    /// </summary>
    [SerializeField]
    float _tornadoSpeed;
    /// <summary>
    /// Posición inicial del tornado
    /// </summary>
    Vector3 _startpos;

    private void Start()
    {
        _startpos = transform.position; //Guarda la posición inicial del tornado, ya que depende de cada nivel
    }

    private void Update()
    {
        if (id < _tornadoPositions.transform.childCount)//Ha pasado el tornado por todos los puntos?
        {
            //almacena la dirección sin normalizar entre el inicio y el fin del movimiento
            Vector2 dir = transform.position - _tornadoPositions.transform.GetChild(id).transform.position;
            //Mueve el tornado
            transform.position = Vector2.MoveTowards(transform.position, _tornadoPositions.transform.GetChild(id).transform.position, _tornadoSpeed * Time.deltaTime);

            if (dir.magnitude < 0.5f)//Pasa al siguiente punto del movimiento
            {
                id++;
            }
        }
        else if((transform.position-_startpos).magnitude > 0.5f) //Volver a la posición inicial
        {
            transform.position = Vector2.MoveTowards(transform.position, _startpos, _tornadoSpeed * Time.deltaTime);
        }
        else //Si ha vuelto a la posición inicial se destruye
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.NuevoTornado();
        Destroy(_tornadoPositions);
    }
}
