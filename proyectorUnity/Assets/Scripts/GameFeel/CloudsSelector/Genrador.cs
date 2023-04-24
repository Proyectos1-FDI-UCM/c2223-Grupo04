using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genrador : MonoBehaviour
{
    [SerializeField] float _IniTime;
    [SerializeField] float _maxTime;
    [SerializeField] GameObject _cloud;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newCloud = Instantiate(_cloud);
        newCloud.transform.position = transform.position + new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_IniTime > _maxTime)
        {
            GameObject newCloud = Instantiate(_cloud);
            newCloud.transform.position = transform.position + new Vector3(0, 0, 0);
            _IniTime = 0;
        }
        else _IniTime += Time.deltaTime;
    }
}
