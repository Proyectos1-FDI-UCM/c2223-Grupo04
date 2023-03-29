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
    /// <summary>
    /// Estados de juego
    /// </summary>
    public enum GameStates
    {
        INTRO, TUTORIAL, GAME, TORNADO, WIN
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
        _inputController = GetComponent<InputController>();
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
            _inputController.MoveOrNot(false); //desacitvar el movimiento
            Debug.Log("STATE: INTRO");
        }

        if (_state == GameStates.TUTORIAL)
        {
            _inputController.MoveOrNot(true); //acitvar el movimiento
            _player.GetComponent<InventoryControllerTutorial>().StartTutorial();
            Debug.Log("STATE: TUTO");
        }

        else if (_state == GameStates.GAME)
        {
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
            Puntuacion.Instance.SetNumeroTornados(nivel, _nTornados, _plantasMuertas);
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

    // Update is called once per frame
    void Update()
    {
        //Comprobaci�n del n�mero de tornados
        if (_nTornados >= _nTornadosFloja)
        {
            Rain();
        } 
    }
}
