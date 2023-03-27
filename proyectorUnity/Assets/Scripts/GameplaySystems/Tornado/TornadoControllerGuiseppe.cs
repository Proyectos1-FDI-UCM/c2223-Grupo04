using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoControllerGuiseppe : TornadoController
{
    private SoilComponent _soilComponent;
    [SerializeField]
    private int _limiteSuperiorRandom;
    [SerializeField]
    private GameObject _piedrasPrefab;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        _soilComponent = collision.GetComponent<SoilComponent>();
        if (!_soilComponent.IsEmpty())
        {
            _soilComponent.RemovePlant();

        }
        else if ((int)Random.Range(0, _limiteSuperiorRandom) == 0)
        {
            _soilComponent.Instanciar(_piedrasPrefab);
        }
        

    }


}
