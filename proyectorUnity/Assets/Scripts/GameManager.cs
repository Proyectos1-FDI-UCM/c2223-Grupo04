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
    public GameObject _player;
    [SerializeField]
    public UIManager _uIManager;
    public InputController _inputController;
    [SerializeField]
    public TornadoSpawner _tornadoSpawner;
    [SerializeField]
    private int _nTornadosFloja;
    private int _nTornadosFuerte;
    [SerializeField]
    private Transform _soilsPapas;
    [SerializeField]
    public LetterByLetterTyping _letterTyper;
    /// <summary>
    /// Estados de juego
    /// </summary>
    public enum GameStates
    {
        INTRO, TUTORIAL, GAME, TORNADO, WIN
    }
    public GameStates _state;
    /// <summary>
    /// Numero de tornados que han pasado
    /// </summary>
    public int _nTornados;
    public int _plantasMuertas;

    //para volver a darle el control al jugador tras pasar un tornado
    float _time;
    bool _goHome;

    [SerializeField] public LevelManager _levelManager;
    private void Awake()
    {
        Instance = this;
        _inputController = GetComponent<InputController>();
    }

    /// <summary>
    /// Se crea un nuevo tornado
    /// </summary>
    public void NuevoTornado()
    {
        _nTornados++;
        _tornadoSpawner.NewTornadoTime();
        _uIManager.NuevoTiempoDeTornado();

    }

    public void Rain()
    {

        for (int i = 0; i < _soilsPapas.childCount; i++)
        {
            _soilsPapas.GetChild(i).GetComponent<SoilComponent>().Fertilice();
        }
        if (_nTornados >= _nTornadosFuerte)
        {
            Camera.main.transform.GetChild(0).gameObject.SetActive(false);//Desactivar las particulas de la lluvia floja.
            Camera.main.transform.GetChild(1).gameObject.SetActive(true); //Activar las particulas de la lluvia fuerte.
        }
        else
        {
            Camera.main.transform.GetChild(0).gameObject.SetActive(true); //Activar las particulas de la lluvia floja.
            Camera.main.transform.GetChild(1).gameObject.SetActive(false); //Activar las particulas de la lluvia fuerte.
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
            _player.GetComponent<PlayerController>().GoHome(); //va a casa
            _inputController.MoveOrNot(false); //desacitvar el movimiento
            Debug.Log("STATE: INTRO");
        }

        if (_state == GameStates.TUTORIAL)
        {
            _player.GetComponent<PlayerController>().GetOutHome(); //sale de casa
            _player.GetComponent<InventoryControllerTutorial>().StartTutorial();
            Debug.Log("STATE: TUTO");
        }
        else if (_state == GameStates.GAME)
        {
            _player.GetComponent<PlayerController>().GetOutHome(); //va a casa
            NuevoTornado();
            Debug.Log("STATE: GAME");
        }
        else if (_state == GameStates.TORNADO)
        {
            _inputController.MoveOrNot(false); //desacitvar el movimiento
            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //cuando estan los tornados la velocicad se deja a cero para evitar que el player se siga moviendo aunque el input est� desactivado
            Debug.Log("STATE: TORNADO");
        }
        else if (_state == GameStates.WIN)
        {
            Time.timeScale = 0; //Parar el tiempo.
            if(Puntuacion.Instance != null){
                Puntuacion.Instance.SetNumeroTornados(nivel, _nTornados, _plantasMuertas);
            }
            Debug.Log("STATE: WIN");
        }
        _uIManager.CambiarUISegunEstadoJuego();
    }

    public void ChangeTutorialMode(GameObject toolObject, string texto) //
    {
        Destroy(_player.GetComponent<InventoryControllerTutorial>());
        _inputController.ChangeTutorialMode(toolObject);

        _uIManager.FinalTextoTutorial(texto);
        ChangeState(GameStates.INTRO);
        
    }
    /// <summary>
    /// pausa o despausa el juego
    /// </summary>
    public void Pause()
    {
        if (Time.timeScale > 0) //Pasar del Game a la Pausa.
        {
            _uIManager.Pausar();
            Time.timeScale = 0; //Parar el tiempo.
        }
        else 
        {
            _uIManager.ContinuarBoton();
        }
    }

    /// <summary>
    /// Establece una cuenta atras para cuando Charlie sale de casa 
    /// </summary>
    /// <param name="time"></param>
    public void OutHome(float time)
    {
        _time = time;
        _goHome = true;
    }

    /// <summary>
    /// reanuda el juego
    /// </summary>
    public void Play()
    {
        if (_state == GameStates.INTRO)
        {
            if (_player.GetComponent<InventoryControllerTutorial>() != null)
            {
                ChangeState(GameManager.GameStates.TUTORIAL);
            }
            else { ChangeState(GameManager.GameStates.GAME); }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _nTornados = 0;
        ChangeState(GameStates.INTRO);
        _nTornadosFuerte = _nTornadosFloja + 3;
        Camera.main.transform.GetChild(0).gameObject.SetActive(false); //Desactivar las partículas de la lluvia floja.
        Camera.main.transform.GetChild(1).gameObject.SetActive(false); //Desactivar las partículas de la lluvia fuerte.
        _goHome = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Comprobacion del numero de tornados
        if (_nTornados >= _nTornadosFloja)
        {
            Rain();
        }

        if (_goHome && _time > 0)
        {
            _time -= Time.deltaTime;
        }
        else if(_goHome && _time <= 0)
        {
            _inputController.MoveOrNot(true); //acitvar el movimiento
            _player.GetComponent<PlayerController>().RestoreOIL();
            _goHome = false;
        }
    }
}
