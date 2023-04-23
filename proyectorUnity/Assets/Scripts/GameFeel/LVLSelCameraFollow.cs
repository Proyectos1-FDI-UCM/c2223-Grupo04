using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLSelCameraFollow : MonoBehaviour
{
    private Transform _myTransform;
    private Vector3 _mousePos;
    [SerializeField]
    float _delay;
    [SerializeField]
    float _velocity;
    [SerializeField]
    GameObject _limitRight;
    [SerializeField]
    GameObject _limitLeft;
    [SerializeField]
    GameObject _puntuacion;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = gameObject.transform;
        _myTransform.position = _limitLeft.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 auxVect;
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!_puntuacion.activeInHierarchy)
        {
            if ((_mousePos.x < _myTransform.position.x - _delay && _myTransform.position.x > _limitLeft.transform.position.x))
            {
                auxVect = _myTransform.position;
                auxVect.x -= _velocity * Time.deltaTime;
                _myTransform.position = auxVect;
            }
            else if ((_mousePos.x > _myTransform.position.x + _delay && _myTransform.position.x < _limitRight.transform.position.x))
            {
                auxVect = _myTransform.position;
                auxVect.x += _velocity * Time.deltaTime;
                _myTransform.position = auxVect;
            }
        }
    }
}
