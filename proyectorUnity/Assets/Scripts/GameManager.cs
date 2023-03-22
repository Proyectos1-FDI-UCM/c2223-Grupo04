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
    int nivel;
    [SerializeField]
    public NivelObjetivos _objetivosNivel;
    [SerializeField]
    public GameObject _player;
    [SerializeField]
    public UIManager _uIManager;
    [SerializeField]
    public TornadoSpawner _tornadoSpawner;
    [SerializeField]
    public bool _lluviaFloja = false;
    [SerializeField]
    public bool _lluviaFuerte = false;
    [SerializeField]
    private int _nTornadosFloja;
    [SerializeField]
    private int _nTornadosFuerte;
    [SerializeField]
    private Transform _soilsPapas;
    /// <summary>
    /// Estados de juego
    /// </summary>
    public enum GameStates
    {
        INTRO, TUTORIAL, GAME, TORNADO, WIN, PAUSA
    }
    public GameStates _state;
    /// <summary>
    /// N�mero de tornados que han pasado
    /// </summary>
    public int _nTornados;
    public int _plantasMuertas;
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
        _lluviaFloja = _nTornados >= _nTornadosFloja;
        _lluviaFuerte = _nTornados >= _nTornadosFuerte;

        //Comprobaci�n del n�mero de tornados
        if (_lluviaFuerte)
        {
            for (int i = 0; i < _soilsPapas.childCount; i++)
            {
                _soilsPapas.GetChild(i).GetComponent<SoilComponent>()._isFertile = true;
            }
            Camera.main.transform.GetChild(0).gameObject.SetActive(false);//Desactivar las partículas de la lluvia floja.
            Camera.main.transform.GetChild(1).gameObject.SetActive(true); //Activar las partículas de la lluvia fuerte.
        }
        else if (_lluviaFloja) 
        {
            for (int i = 0; i < _soilsPapas.childCount; i++)
            {
                _soilsPapas.GetChild(i).GetComponent<SoilComponent>().RegarPlant();
                print("La lluvia riega");
            }
            Camera.main.transform.GetChild(0).gameObject.SetActive(true); //Activar las partículas de la lluvia floja.
        }
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

        if (_state == GameStates.TUTORIAL)
        {
            gameObject.GetComponent<InputController>().enabled = true; //activar el input
            _player.GetComponent<InventoryControllerTutorial>().StartTutorial();
            Debug.Log("STATE: TUTO");
        }

        else if (_state == GameStates.GAME)
        {
            gameObject.GetComponent<InputController>().enabled = true; //activar el input
            NuevoTornado();
            Debug.Log("STATE: GAME");
        }
        else if (_state == GameStates.TORNADO)
        {
            gameObject.GetComponent<InputController>().enabled = false; //desactivar el input
            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //cuando estan los tornados la velocicad se deja a cero para evitar que el player se siga moviendo aunque el input est� desactivado
            Debug.Log("STATE: TORNADO");
        }
        else if (_state == GameStates.WIN)
        {
            Time.timeScale = 0; //Parar el tiempo.
            Puntuacion.Instance.SetNumeroTornados(nivel, _nTornados, _plantasMuertas);
            Debug.Log("STATE: WIN");
        }/*
        else if(_state == GameStates.PAUSA)
        {
            Time.timeScale = 0; //Parar el tiempo.

            Debug.Log("STATE: PAUSA");
        }*/
        _uIManager.CambiarUISegunEstadoJuego();
    }

    public void ChangeTutorialMode(GameObject toolObject, string texto) //
    {
        Destroy(_player.GetComponent<InventoryControllerTutorial>());
        gameObject.GetComponent<InputController>().ChangeTutorialMode(toolObject);

        _uIManager.FinalTextoTutorial(texto);
        ChangeState(GameStates.INTRO);
        

        //llamar a ui para q de mensaje final

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _nTornados = 0;
        ChangeState(GameStates.INTRO);
        _nTornadosFuerte = _nTornadosFloja + 3;
        Camera.main.transform.GetChild(0).gameObject.SetActive(false); //Desactivar las partículas de la lluvia floja.
        Camera.main.transform.GetChild(1).gameObject.SetActive(false); //Desactivar las partículas de la lluvia fuerte.

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) NuevoTornado();
        
        if (_state == GameStates.INTRO && Input.GetMouseButtonDown(0)) //Pasar de la Intro o la Pausa al Game.
        {
            if (_player.GetComponent<InventoryControllerTutorial>() != null)
                GameManager.Instance.ChangeState(GameManager.GameStates.TUTORIAL);
            else
                GameManager.Instance.ChangeState(GameManager.GameStates.GAME);
        }
        if (Input.GetKeyDown(KeyCode.P) && _state == GameStates.GAME) //Pasar del Game a la Pausa.
        {
            _uIManager.Pausar();
            Time.timeScale = 0; //Parar el tiempo.
        }
    }
}
