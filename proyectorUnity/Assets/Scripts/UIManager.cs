using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    float _time;

    [SerializeField] TextMeshProUGUI _contador;
    [SerializeField] GameObject _introUI, _gameUI, _pausaUI, _winUI;

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
            _contador.text = (int)(_time / 60) + ":" + (int)(_time % 60);
            _time = _time - Time.deltaTime;
        }
        else _contador.text = "¡TORNADO!"; //Cuando acaba el contador y el tornado esta en juego ponemos esto por ejemplo.
        
        if (GameManager.Instance._state == GameManager.GameStates.INTRO)
        {
            _introUI.SetActive(true);  
            _gameUI.SetActive(false);
            _winUI.SetActive(false);
            _pausaUI.SetActive(false);
        }
        else if(GameManager.Instance._state == GameManager.GameStates.GAME)
        {
            _introUI.SetActive(false);
            _gameUI.SetActive(true);
            _winUI.SetActive(false);
            _pausaUI.SetActive(false);
        }
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
