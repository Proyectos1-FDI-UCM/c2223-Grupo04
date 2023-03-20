using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpawner : MonoBehaviour
{
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
        Camera.main.GetComponent<SmoothCameraFollow>().target = GameManager.Instance._player.transform;
    }

    IEnumerator TiempoSpawn()
    {

        yield return new WaitForSeconds(_tEntreTornados + _tMul); // esperar tiempo base + la cantidad de tornados que hayan pasado * 10
        _tMul = (10 * GameManager.Instance._nTornados);//Suma el multiplicador al de tiempo
        GameManager.Instance._player.GetComponent<PlayerController>()._irACasa = true;
        
        //Elige una ruta random de las prefijadas
        int _idRuta = Random.Range(0, _tornadoRutas.Length);
        //Instancia la ruta del tornado
        GameObject _ruta = GameObject.Instantiate(_tornadoRutas[_idRuta], null);
        //Instancia el tornado
        GameObject _tornado = GameObject.Instantiate(_tornadoPrefab, _tornadoInstPos);
        //Camara sigue al tornado
        Camera.main.GetComponent<SmoothCameraFollow>().target = _tornado.transform.GetChild(0).transform;
        //Asigna la ruta al tornado
        _tornado.GetComponent<TornadoController>()._tornadoPositions = _ruta;
    }
}
