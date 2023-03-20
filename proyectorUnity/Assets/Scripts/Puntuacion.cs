using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [SerializeField]
    private int[] _numeroTornados;
    public static Puntuacion Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _numeroTornados = new int[4];
    }

    public int GetNumeroTornados(int nivel)
    {
        return _numeroTornados[nivel];
    }

    public void SetNumeroTornados(int nivel, int tornados)
    {
        print("GUARDA LA PUNTUACION");

        if (_numeroTornados[nivel] < tornados - 1) 
        {
            _numeroTornados[nivel] = tornados - 1;
        }
    }


}
