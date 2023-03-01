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
    [SerializeField] Image _inventory;
    
    InventoryController _inventoryController2;

    public static UIManager Instance; //Para el singletone.
    
    // Start is called before the first frame update
    void Start()
    {
        
        _inventoryController2 = PlayerController.Instance._inventoryController;
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
        this.enabled = true;
        Instance = this;
        GameManager.Instance._uIManager = this;
    }

    #region methods
    public void NuevoTiempoDeTornado() //Es llamado por el GameManager para coger el nuevo tiempo del nuevo tornado.
    {
        _time = TornadoSpawner.Instance._tMul + TornadoSpawner.Instance._tEntreTornados; 
    }
    public void changeInventory(GameObject tool)
    {
        if (tool != null)
        {
            _inventory.enabled = true;
            _inventory.sprite = tool.GetComponent<SpriteRenderer>().sprite;
        }
        else 
        {
            _inventory.enabled = false;
        }
    }
    #endregion
}
