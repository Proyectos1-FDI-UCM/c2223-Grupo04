using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    [SerializeField]
    GameObject _tornadoPositions;
    [SerializeField]
    float _tornadoSpeed;
    Vector3 _startpos;
    [SerializeField]
    int id = 0;

    private void Start()
    {
        _startpos = transform.position;
    }

    private void Update()
    {
        if (id < _tornadoPositions.transform.childCount)
        {
            Vector2 dir = transform.position - _tornadoPositions.transform.GetChild(id).transform.position;
            transform.position = Vector2.MoveTowards(transform.position, _tornadoPositions.transform.GetChild(id).transform.position, _tornadoSpeed * Time.deltaTime);
            print("WWWW");
            if (dir.magnitude < 0.5f)
            {
                id++;
            }
        }
        else if((transform.position-_startpos).magnitude > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, _startpos, _tornadoSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
