using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TornadoSpawner : MonoBehaviour
{
    

    /// <summary>
    /// Singleton del spawner del tornado
    /// </summary>
    public static TornadoSpawner Instance { get; private set; }
    /// <summary>
    /// Tiempo que pasa entre tornados
    /// </summary>
    [SerializeField]
    public float _tEntreTornados;
    /// <summary>
    /// Tiempo que se suma cada vez que aparece un tornado
    /// </summary>
    public int _tMul = 0;
    /// <summary>
    /// Prefab del tornado
    /// </summary>
    [SerializeField]
    GameObject _tornadoPrefab;
    /// <summary>
    /// Posición de instanciar tornado
    /// </summary>
    [SerializeField]
    Transform _tornadoInstPos;
    /// <summary>
    /// Rutas de tornados
    /// </summary>
    [SerializeField]
    GameObject[] _tornadoRutas;

    /// <summary>
    /// Espera entre tornados
    /// </summary>
    public void NewTornadoTime()
    {
        StartCoroutine(TiempoSpawn());
        SmoothCameraFollow.Instance.target = PlayerController.Instance.gameObject.transform;
    }

    IEnumerator TiempoSpawn()
    {

        yield return new WaitForSeconds(_tEntreTornados + _tMul); // esperar tiempo base + la cantidad de tornados que hayan pasado * 10
        _tMul = (10 * GameManager.Instance._nTornados);//Suma el multiplicador al de tiempo
        PlayerController.Instance._irACasa = true;
        
        //Elige una ruta random de las prefijadas
        int _idRuta = Random.Range(0, _tornadoRutas.Length);
        print(_idRuta);
        //Instancia la ruta del tornado
        GameObject _ruta = GameObject.Instantiate(_tornadoRutas[_idRuta], null);
        //Instancia el tornado
        GameObject _tornado = GameObject.Instantiate(_tornadoPrefab, _tornadoInstPos);
        //Camara sigue al tornado
        SmoothCameraFollow.Instance.target = _tornado.transform;
        //Asigna la ruta al tornado
        _tornado.GetComponent<TornadoMovement>()._tornadoPositions = _ruta;
    }
    private void Awake()
    {
        Instance = this;
    }
}
