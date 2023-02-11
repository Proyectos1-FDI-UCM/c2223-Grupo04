using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Obliga a que el objeto contenga un componente Rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("La velocidad de moviemiento del personaje")]
    float speed;
    Vector2 direction;
    private void Start()
    {
        direction = new Vector2(0, 0);
    }

    private void LateUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void Stop()
    {
        direction.x = 0;
        direction.y = 0;
    }

    public void Up()
    {
        if(direction.y == 0)
            direction.y = 1;
    }
    public void Down()
    {
        if (direction.y == 0)
            direction.y = -1;
    }
    public void Left()
    {
        if (direction.x == 0)
            direction.x = -1;
    }
    public void Right()
    {
        if (direction.x == 0)
            direction.x = 1;
    }
}
