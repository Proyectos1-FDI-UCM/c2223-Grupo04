using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Instancia del GameManager
    /// </summary>
    public static GameManager Instance { get; private set; }
    [SerializeField]
    public GameObject _player;
    [SerializeField]
    public UIManager _uIManager;
    [SerializeField]
    public TornadoSpawner _tornadoSpawner;
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
    [SerializeField] public LevelManager _levelManager;
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
        _tornadoSpawner.NewTornadoTime();
        UIManager.Instance.NuevoTiempoDeTornado();
    }
    public void ChangeState(GameStates _newState)
    {
        _state = _newState;
        StateExecution();
    }
    void StateExecution()
    {
        if(_state == GameStates.INTRO)
        {
            gameObject.GetComponent<InputController>().enabled = false; //desacitvar el input
            Debug.Log("STATE: INTRO");
        }
        else if (_state == GameStates.GAME)
        {
            gameObject.GetComponent<InputController>().enabled = true; //activar el input
            NuevoTornado();
            Debug.Log("STATE: GAME");
        } 
        else if(_state==GameStates.TORNADO)
        {
            gameObject.GetComponent<InputController>().enabled = false; //desactivar el input
            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //cuando estan los tornados la velocicad se deja a cero para evitar que el player se siga moviendo aunque el input esté desactivado
            Debug.Log("STATE: TORNADO");
        }
        else if (_state == GameStates.WIN)
        {
            Time.timeScale = 0; //Parar el tiempo.

            Debug.Log("STATE: WIN");
        }/*
        else if(_state == GameStates.PAUSA)
        {
            Time.timeScale = 0; //Parar el tiempo.

            Debug.Log("STATE: PAUSA");
        }*/
        _uIManager.CambiarUISegunEstadoJuego();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _nTornados = 0;
        ChangeState(GameStates.INTRO);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) NuevoTornado();
        
        if (Input.GetMouseButtonDown(0) && _state == GameStates.INTRO) //Pasar de la Intro o la Pausa al Game.
        {
            GameManager.Instance.ChangeState(GameManager.GameStates.GAME);
        }
        if (Input.GetKeyDown(KeyCode.P) && _state == GameStates.GAME) //Pasar del Game a la Pausa.
        {
            _uIManager.Pausar();
            Time.timeScale = 0; //Parar el tiempo.
        }
    }
}
