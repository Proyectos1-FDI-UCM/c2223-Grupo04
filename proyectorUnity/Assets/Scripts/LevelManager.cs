using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    private NivelObjetivos objetivos;
    private ScriptablePlant[] plantasObjetivo;
    private int[] cantidadObjetivo;
    private int[] progreso;
    private List<PlantaBehaviour> plantas;

    // Start is called before the first frame update
    void Start()
    {
        plantas = new List<PlantaBehaviour>();
        plantasObjetivo = objetivos.plantas;
        cantidadObjetivo = objetivos.cantidad;
        progreso = new int[plantasObjetivo.Length];
        //GameManager.Instance._uIManager.SetearObjetivos(objetivos); //Pasamos lo objetivos al método del UIManager.
        GameManager.Instance._uIManager.objetivosnivel = objetivos;
    }

    #region methods
    private void ComprobarComplecion()
    {
        int i = 0;
        bool complecion = true;
        while(i < plantasObjetivo.Length && complecion)
        {
            complecion = cantidadObjetivo[i] < progreso[i];
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
        Debug.Log("Planta crecida" + progreso[FindIndex(scriptablePlant)]);
        GameManager.Instance._uIManager.UpdatearObjetivosUI(progreso[FindIndex(scriptablePlant)], FindIndex(scriptablePlant));
        ComprobarComplecion();
    }

    public void PlantDied(ScriptablePlant scriptablePlant)
    {
        progreso[FindIndex(scriptablePlant)]--;
        Debug.Log("planta morida" + progreso[FindIndex(scriptablePlant)]);
        GameManager.Instance._uIManager.UpdatearObjetivosUI(progreso[FindIndex(scriptablePlant)], FindIndex(scriptablePlant));
        ComprobarComplecion();
    }

    private int FindIndex(ScriptablePlant scriptablePlant)
    {
        bool encontrado = false;
        int i = 0;
        while (i < plantasObjetivo.Length && !encontrado)
        {
            encontrado = scriptablePlant == plantasObjetivo[i];
            i++;
        }
        return i - 1;
    }

    public void AddPlant(PlantaBehaviour miPlanta)
    {
        plantas.Add(miPlanta);
    }

    public void RemovePlant(PlantaBehaviour miPlanta)
    {
        plantas.Remove(miPlanta);
    }

    public PlantaBehaviour GetGrownPlant()
    {
        List<PlantaBehaviour> plantasGrowadas = new List<PlantaBehaviour>();
        int c = 0;
        while(c < plantas.Count)
        {
            if (plantas[c].GetPlantState() == PlantaBehaviour.PlantState.Drying) {
                plantasGrowadas.Add(plantas[c]);
            }
        }
        return plantasGrowadas[UnityEngine.Random.Range(0, plantasGrowadas.Count)];
    }
    #endregion
}
