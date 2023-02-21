using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    float _time;
    
    [SerializeField] Text _contador;

    public static UIManager Instance; //Para el singletone.
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > 0)
        {
            _contador.text = _time.ToString();
            _time = _time - Time.deltaTime;
        }
        else _contador.text = "¡TORNADO!"; //Cuando acaba el contador y el tornado esta en juego ponemos esto por ejemplo.
    }
    private void Awake() //Para el singletone.
    {
        Instance = this;
    }

    #region methods
    public void NuevoTiempoDeTornado() //Es llamado por el GameManager para coger el nuevo tiempo del nuevo tornado.
    {
        _time = TornadoSpawner.Instance._tMul + TornadoSpawner.Instance._tEntreTornados; 
    }
    #endregion
}
