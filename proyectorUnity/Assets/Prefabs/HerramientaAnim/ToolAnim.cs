using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAnim : MonoBehaviour
{
    float _timeToDestroy;
    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _timeToDestroy = _anim.GetCurrentAnimatorStateInfo(0).length;
    }
    private void Update()
    {
        if (_timeToDestroy <=0)
        {
            Destroy(gameObject);
        }
        else
        {
            _timeToDestroy -= Time.deltaTime;
        }
    }
}
