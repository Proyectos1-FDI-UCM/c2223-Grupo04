using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public void RemoveObstacle()
    {
        transform.parent.GetComponent<SoilComponent>().SetIsEmpty(true);
        Destroy(gameObject);
    }
}
