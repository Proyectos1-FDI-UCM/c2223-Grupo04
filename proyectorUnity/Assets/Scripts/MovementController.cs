using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Obliga a que el objeto contenga un componente Rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("La velocidad de moviemiento del personaje")]
    public float _speed;
    Vector2 _direction;
    Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _direction = new Vector2(0, 0);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float h, float v)
    {
        _direction = new Vector2(h, v);
        _rigidbody2D.velocity = _direction * _speed;
    } 
    /*
    private void LateUpdate()
    {
        _rigidbody2D.velocity = _direction.normalized * _speed;
    }

    public void Stop()
    {
        _direction.x = 0;
        _direction.y = 0;
    }

    public void Up()
    {
        if(_direction.y == 0)
            _direction.y = 1;
    }
    public void Down()
    {
        if (_direction.y == 0)
            _direction.y = -1;
    }
    public void Left()
    {
        if (_direction.x == 0)
            _direction.x = -1;
    }
    public void Right()
    {
        if (_direction.x == 0)
            _direction.x = 1;
    }*/
}
