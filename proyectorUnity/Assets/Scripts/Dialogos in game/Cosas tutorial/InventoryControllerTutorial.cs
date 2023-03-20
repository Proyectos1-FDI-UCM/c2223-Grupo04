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
    private string[] _parteActualName;
    private bool _semillaCogida;
    [SerializeField]
    private DialogoSO _dialogos;
    [SerializeField]
    private float _tiempoEspera;
    private GameManager _gameManager;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        
        _parteActual= ParteTutorial.plantando;
        _semillaCogida= false;
        _gameManager = GameManager.Instance;
        _uiManager = _gameManager._uIManager;

    }

    public void StartTutorial()
    {
        _uiManager.TextoTutorial(_dialogos._dialogos[0], _tiempoEspera);

    }

    public override void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {

        if ((int)(_parteActual) == System.Array.IndexOf(Herramientas, toolObject) || base.GetTool() == toolObject)
        {

            base.TryPickUpTool(toolObject, mousePos);
            if (!_semillaCogida)
            {
                _uiManager.TextoTutorial(_dialogos._dialogos[1], _tiempoEspera);
                _semillaCogida = true;

            }
        }

    }

    public override void ClickFunction(GameObject objetoClicado, Vector2 mousePos)
    {
        base.ClickFunction(objetoClicado, mousePos);
        if ((int)_parteActual == 2)
            _gameManager.ChangeTutorialMode(base.GetTool(), _dialogos._dialogos[4]);

        else
        {
            _parteActual++;
            _uiManager.TextoTutorial(_dialogos._dialogos[(int)_parteActual + 1], _tiempoEspera);

        }

    }

}
