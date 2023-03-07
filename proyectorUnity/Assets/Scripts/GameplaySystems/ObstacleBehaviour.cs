using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public void RemoveObstacle(float espera)
    {
        StartCoroutine(Espera(espera));
    }

    IEnumerator Espera(float espera)
    {
        yield return new WaitForSeconds(espera);
        Destroy(gameObject);
    }

}
