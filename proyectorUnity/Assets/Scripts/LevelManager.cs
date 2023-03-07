using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// <summary>
    /// Comprueba si se cumplen los objetivos del nivel.
    /// En caso afirmativo llama al GameManager para notifiar de victoria.
    /// </summary>
    private void ComprobarComplecion()
    {
        int i = 0;
        bool complecion = true;
        while(i < plantasObjetivo.Length && complecion)
        {
            complecion = cantidadObjetivo[i] <= progreso[i];
            i++;
        }

        if (complecion)
        {
            //TODO NIVEL COMPLETADO
            Debug.Log("Te lo has pasado!");
            GameManager.Instance.ChangeState(GameManager.GameStates.WIN);
        }
    }

    /// <summary>
    /// Aumenta en uno el contador de objetivos del tipo de planta pasada como parámetro.
    /// </summary>
    /// <param name="scriptablePlant">El tipo de planta que se ha puntuado</param>
    public void PlantHasGrown(ScriptablePlant scriptablePlant)
    {
        int index = FindIndex(scriptablePlant);
        progreso[index]++;
        Debug.Log("Planta crecida" + progreso[index]);
        GameManager.Instance._uIManager.UpdatearObjetivosUI(progreso[index], index);
        ComprobarComplecion();
    }
    /// <summary>
    /// Quita la planta del level manager, también llama a reducir el contador si es pertinente.
    /// </summary>
    /// <param name="planta">El componente de la planta a eliminar.</param>
    public void RemovePlant(PlantaBehaviour planta)
    {
        if(planta.GetPlantState() == PlantaBehaviour.PlantState.Drying || planta.GetPlantState() == PlantaBehaviour.PlantState.Dead)
        {
            ScriptablePlant scriptablePlant = planta.GetPlantData();
            DiscountPlant(scriptablePlant);
        }   
        plantas.Remove(planta);
    }

    /// <summary>
    /// Reduce en uno el contador de objetivos del tipo de planta pasada como parámetro.
    /// </summary>
    /// <param name="scriptablePlant">El tipo de planta que se ha "perdido".</param>
    public void DiscountPlant(ScriptablePlant scriptablePlant)
    {
        int index = FindIndex(scriptablePlant);
        progreso[index]--;
        GameManager.Instance._uIManager.UpdatearObjetivosUI(progreso[index], index);
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
    /// <summary>
    /// Busca de entre todas las plantas del nivel una que esté crecida del todo.
    /// </summary>
    /// <returns>Un PlantaBeahavior adecuado, null si no ha encontrado ninguno.</returns>
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
        if (plantasGrowadas.Any())
            planta = plantasGrowadas[UnityEngine.Random.Range(0, plantasGrowadas.Count)];
        return planta;
    }
    #endregion
}
