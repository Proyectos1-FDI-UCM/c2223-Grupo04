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
    private Tool[] Herramientas;
    private ParteTutorial _parteActual;
    private string[] _parteActualName;
    private bool _semillaCogida;
    [SerializeField]
    private DialogoSO _dialogos;
    private GameManager _gameManager;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<InventoryController>().enabled = false;
        _parteActual= ParteTutorial.plantando;
        _semillaCogida= false;
        _gameManager = GameManager.Instance;
        _uiManager = _gameManager._uIManager;


        _uiManager.TextoTutorial(_dialogos._dialogos[0]);


    }

    public override void TryPickUpTool(GameObject toolObject, Vector2 mousePos)
    {

        if ((int)(_parteActual) == System.Array.IndexOf(Herramientas, toolObject))
        {
            base.TryPickUpTool(toolObject, mousePos);
            if (!_semillaCogida)
            {
                _uiManager.TextoTutorial(_dialogos._dialogos[1]);
                _semillaCogida = true;

            }
        }

    }

    public override void ClickFunction(GameObject objetoClicado, Vector2 mousePos)
    {
        base.ClickFunction(objetoClicado, mousePos);
        if ((int)_parteActual == 2)
            Debug.Log("a"); //llamar al gamemanager para q cambie el inventory y llame al ultimo mensaje de la ui
        else
        {
            _parteActual++;
            _uiManager.TextoTutorial(_dialogos._dialogos[(int)_parteActual]+1);

        }

    }

}
