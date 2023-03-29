using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(UnityEngine.Rendering.Universal.Light2D))]
public class HiglightItem : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]
    private float _distanciaMinimaIluminado;
    private UnityEngine.Rendering.Universal.Light2D _myLight;

    private void Start()
    {
        _playerTransform = GameManager.Instance._player.gameObject.transform;
        _myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        _myLight.intensity = 0;
    }


    private void OnMouseOver()
    {
        if (_myLight.intensity == 0 && Vector2.Distance(_playerTransform.position, gameObject.transform.position) < _distanciaMinimaIluminado)
        {
            _myLight.intensity = 1;
        }
    }

    private void OnMouseExit() 
    {
        _myLight.intensity = 0;
        
    }

}
