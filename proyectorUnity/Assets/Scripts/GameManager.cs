using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Instancia del GameManager
    /// </summary>
    public static GameManager Instance { get; private set; }
    /// <summary>
    /// Estados de juego
    /// </summary>
    public enum GameStates
    {
        INTRO, GAME, TORNADO, WIN, PAUSA
    }
    public GameStates _state;
    /// <summary>
    /// Número de tornados que han pasado
    /// </summary>
    public int _nTornados;
    [SerializeField]
    public LevelManager _levelManager;
    private void Awake()
    {
        Instance = this;
    }

    #region methods
    /// <summary>
    /// Se crea un nuevo tornado
    /// </summary>
    public void NuevoTornado()
    {
        _nTornados++;
        TornadoSpawner.Instance.NewTornadoTime();
        UIManager.Instance.NuevoTiempoDeTornado();
    }
    public void ChangeState(GameStates _newState)
    {
        _state = _newState;
    }
    void StateExecution()
    {
        if(_state == GameStates.INTRO)
        {
            PlayerController.Instance.gameObject.GetComponent<InputController>().enabled = false; //desacitvar el input
        }
        else if (_state == GameStates.GAME)
        {
            PlayerController.Instance.gameObject.GetComponent<InputController>().enabled = true;

        }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _nTornados = 0;
        _state = GameStates.INTRO;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) NuevoTornado();
    }
}
