using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    private NivelObjetivos objetivos;
    private ScriptablePlant[] plantas;
    private int[] cantidad;
    private int[] progreso;
    // Start is called before the first frame update
    void Start()
    {
        plantas = objetivos.plantas;
        cantidad = objetivos.cantidad;
        progreso = new int[plantas.Length];
    }

    // Update is called once per frame
    private void ComprobarComplecion()
    {
        int i = 0;
        bool complecion = true;
        while(i < plantas.Length && complecion)
        {
            complecion = cantidad[i] < progreso[i];
            i++;
        }

        if (complecion)
        {
            //TODO NIVEL COMPLETADO
            Debug.Log("Te lo has pasao!");
        }
    }

    public void PlantHasGrown(ScriptablePlant scriptablePlant)
    {
        progreso[FindIndex(scriptablePlant)]++;
        Debug.Log("planta crecida" + progreso[FindIndex(scriptablePlant)]);

    }

    public void PlantDied(ScriptablePlant scriptablePlant)
    {
        progreso[FindIndex(scriptablePlant)]--;
        Debug.Log("planta morida" + progreso[FindIndex(scriptablePlant)]);

    }

    private int FindIndex(ScriptablePlant scriptablePlant)
    {
        bool encontrado = false;
        int i = 0;
        while (i < plantas.Length && !encontrado)
        {
            encontrado = scriptablePlant == plantas[i];
            i++;
        }
        return i - 1;
    }
}
