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
    enum GameStates
    {
        INTRO,GAME,TORNADO,WIN,PAUSA 
    }
    /// <summary>
    /// Referencia al jugador
    /// </summary>
    [SerializeField]
    GameObject _player;
    /// <summary>
    /// Número de tornados que han pasado
    /// </summary>
    public int _nTornados;

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
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _nTornados = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) NuevoTornado();
    }

    public GameObject getPlayer()
    {
        return _player;
    }
}
