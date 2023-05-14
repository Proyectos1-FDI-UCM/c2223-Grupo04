using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerTutorial : InventoryController
{
//coger semilla, plantar normal, plantar soil fértil, quitar piedra, regar
   
    
   private enum ParteTutorial
    {
        cogerSemilla1,
        cogerSemilla2,
        plantar,
        plantarFertil,
        cogerRegadera,
        regar,
        dejarRegadera,
        cogerPala,
        usarPala
    }
    

    [SerializeField]
    private GameObject[] ObjetosAInteractuar;
    [SerializeField]
    private GameObject _luz;
    [SerializeField]
    private ParteTutorial _parteActual;

    
    
    [SerializeField]
    private DialogoSO _dialogos;
 

    private GameManager _gameManager;
    private UIManager _uiManager;

    
   

    // Start is called before the first frame update
    void Start()
    {        
        _parteActual= ParteTutorial.cogerSemilla1;
        
        _gameManager = GameManager.Instance;
        _uiManager = _gameManager._uIManager;

        _luz.SetActive(false);
        
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
        if (Vector2.Distance(gameObject.transform.position, toolObject.transform.position) < base._distanciaMin)
        {

            if (toolObject == ObjetosAInteractuar[(int)_parteActual])
            {
                base.TryPickUpTool(toolObject, mousePos);
                _parteActual++;
                _uiManager.TextoTutorial(_dialogos._dialogos[(int)_parteActual]);
                MoverLuz();
            }
            if (_parteActual == ParteTutorial.cogerSemilla2)
            {
                _uiManager.MostrarControles(false);
            }
        }
        
    }

    public override void ClickFunction(GameObject objetoClicado, Vector2 mousePos)
    {
        if (Vector2.Distance(gameObject.transform.position, objetoClicado.transform.position) < base._distanciaMin)
        {
            if (_parteActual == ParteTutorial.usarPala && objetoClicado == ObjetosAInteractuar[8].transform.GetChild(1).gameObject)
            {
                base.ClickFunction(objetoClicado, mousePos);
                _gameManager.ChangeTutorialMode(base.GetTool(), _dialogos._dialogos[9]);
                Destroy(_luz);
            }


            else if (objetoClicado == ObjetosAInteractuar[(int)_parteActual])
            {
                base.ClickFunction(objetoClicado, mousePos);
                _parteActual++;
                MoverLuz();
                _uiManager.TextoTutorial(_dialogos._dialogos[(int)_parteActual]);

            }
        }
    }

    private void MoverLuz()
    {
        _luz.transform.position = ObjetosAInteractuar[(int)_parteActual].transform.position;
        //Debug.Log("luz Movida");
    }

}
