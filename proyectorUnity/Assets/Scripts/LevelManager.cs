using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Debug.Log("Te lo has pasado!");
            GameManager.Instance.ChangeState(GameManager.GameStates.WIN);
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
    /// <summary>
    /// Busca de entre todas las plantas del nivel una que esté crecida del todo.
    /// </summary>
    /// <returns>Un PlantaBeahavior adecuado, null si no ha encontrado ninguno</returns>
    public PlantaBehaviour GetGrownPlant()
    {
        PlantaBehaviour planta = null;
        List<PlantaBehaviour> plantasGrowadas = new List<PlantaBehaviour>();
        for( int c= 0; c < plantas.Count; c++)
        {
            Debug.Log(plantas[c].GetPlantState().ToString());
            if (plantas[c].GetPlantState() == PlantaBehaviour.PlantState.Drying) {
                plantasGrowadas.Add(plantas[c]);
            }
        }
        //si no ha encontrado ninguna planta crecida, devuelve nullz
        if (plantasGrowadas.Any())
            planta = plantasGrowadas[UnityEngine.Random.Range(0, plantasGrowadas.Count)];
        return planta;
    }
    #endregion
}
