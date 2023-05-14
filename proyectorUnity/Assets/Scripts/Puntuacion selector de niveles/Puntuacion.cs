using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [SerializeField]
    private int _nivelActual;
    [SerializeField]
    private int[] _numeroTornados;
    [SerializeField]
    private int[] _numeroPlantasSecas;
    public static Puntuacion Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _numeroTornados = new int[5];
        _numeroPlantasSecas = new int[5];
       
        DontDestroyOnLoad(gameObject);
    }
    
    public int GetNivelActual()
    {
        return _nivelActual;
    }

    public int GetNumeroTornados(int nivel)
    {
        return _numeroTornados[nivel];
    }

    public int GetNumeroPlantasSecas(int nivel)
    {
        return _numeroPlantasSecas[nivel];
    }

    public void SetNivelActual(int nivel)
    {
        _nivelActual = nivel;
    }
    public void SetNumeroTornados(int nivel, int tornados, int plantasMuertas)
    {
        //print("GUARDA LA PUNTUACION");

        _numeroTornados[nivel] = tornados - 1;
        _numeroPlantasSecas[nivel] = plantasMuertas;
        _nivelActual++;
        
        /*
        if (_puntuacion[nivel] < 100 - ((tornados-1) + plantasMuertas)) 
        {
            _numeroTornados[nivel] = tornados - 1;
            _numeroPlantasSecas[nivel] = plantasMuertas;
        }*/
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetNivelActual(5);
        }
    }
}
