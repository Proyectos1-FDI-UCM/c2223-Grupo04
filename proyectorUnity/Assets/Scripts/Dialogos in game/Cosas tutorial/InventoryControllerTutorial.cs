using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerTutorial : InventoryController
{
    private enum ParteTutorial
    {
        plantando, 
        regando,
        pala
    };

    [SerializeField]
    private GameObject[] Herramientas;
    private ParteTutorial _parteActual;

    
    private bool _semillaCogida;
    [SerializeField]
    private DialogoSO _dialogos;
    [SerializeField]
    private float _tiempoEspera;
    private GameManager _gameManager;
    private UIManager _uiManager;

    [SerializeField]
    private GameObject[] _posicionesLuces;
    [SerializeField]
    private GameObject _luz, _soil, _soilPiedras;
    private int _luzNumero;
    private bool _hasOnClick;

    // Start is called before the first frame update
    void Start()
    {
        
        _parteActual= ParteTutorial.plantando;
        _semillaCogida= false;
        _gameManager = GameManager.Instance;
        _uiManager = _gameManager._uIManager;
        _luzNumero=0;
        _luz.SetActive(false);
        _hasOnClick = true;

       
    }

    public void StartTutorial()
    {
        _uiManager.TextoTutorial(_dialogos._dialogos[0]);
        _uiManager.MostrarControles(true);
        _luz.SetActive(true);
        MoverLuz();


    }

    public override void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {

        if ((int)(_parteActual) == System.Array.IndexOf(Herramientas, toolObject) || base.GetTool() == toolObject)
        {
            Debug.Log("aaaaa");

            if ( base.GetTool() == null && _hasOnClick) 
            {
                MoverLuz();
                _hasOnClick = false;
                Debug.Log("EEEEEEEEEE");

            }

            base.TryPickUpTool(toolObject, mousePos);

            if (!_semillaCogida)
            {
                _uiManager.TextoTutorial(_dialogos._dialogos[1]);
                _uiManager.MostrarControles(false);
                _semillaCogida = true;

            }

            
        }

    }

    public override void ClickFunction(GameObject objetoClicado, Vector2 mousePos)
    {
        if ( objetoClicado == _soil && (int)_parteActual < 2) 
        {
            Debug.Log("ok i pull up");
            base.ClickFunction(objetoClicado, mousePos);
            _parteActual++;
            _uiManager.TextoTutorial(_dialogos._dialogos[(int)_parteActual + 1]);
            MoverLuz();
            _hasOnClick = true;
            Debug.Log("iiii");


        }

        else 
        {
            Debug.Log("tu madre");
            base.ClickFunction(objetoClicado, mousePos);
            _gameManager.ChangeTutorialMode(base.GetTool(), _dialogos._dialogos[4]);
            Destroy(_luz);
        }
            


    }

    private void MoverLuz()
    {
        _luz.transform.position = _posicionesLuces[_luzNumero].transform.position;
        _luzNumero++;
        Debug.Log("luz Movida");
    }

}
