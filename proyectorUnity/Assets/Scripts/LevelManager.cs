using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    public NivelObjetivos objetivos;
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
        //GameManager.Instance._uIManager.SetearObjetivos(objetivos); //Pasamos lo objetivos al m�todo del UIManager.
        //GameManager.Instance._uIManager._objetivosnivel = objetivos;
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
            GameManager.Instance.GanarPartida();
        }
    }

    /// <summary>
    /// Aumenta en uno el contador de objetivos del tipo de planta pasada como par�metro.
    /// </summary>
    /// <param name="scriptablePlant">El tipo de planta que se ha puntuado</param>
    public void PlantHasGrown(ScriptablePlant scriptablePlant)
    {
        int index = FindIndex(scriptablePlant);
        progreso[index]++;
        GameManager.Instance._uIManager.UpdatearObjetivosUI(progreso[index], index);
        ComprobarComplecion();
    }
    /// <summary>
    /// Quita la planta del level manager, tambi�n llama a reducir el contador si es pertinente.
    /// </summary>
    /// <param name="planta">El componente de la planta a eliminar.</param>
    public void RemovePlant(PlantaBehaviour planta)
    {
        if(planta.GetPlantState() == PlantaBehaviour.PlantState.Drying)
        {
            ScriptablePlant scriptablePlant = planta.GetPlantData();
            DiscountPlant(scriptablePlant);
        }
        plantas.Remove(planta);
    }

    public void PlantaSeca(PlantaBehaviour planta)
    {
        ScriptablePlant scriptablePlant = planta.GetPlantData();
        DiscountPlant(scriptablePlant);
        GameManager.Instance._plantasMuertas ++;
    }

    /// <summary>
    /// Reduce en uno el contador de objetivos del tipo de planta pasada como par�metro.
    /// </summary>
    /// <param name="scriptablePlant">El tipo de planta que se ha "perdido".</param>
    private void DiscountPlant(ScriptablePlant scriptablePlant)
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
    /// Busca de entre todas las plantas del nivel una que est� crecida del todo.
    /// </summary>
    /// <returns>Un PlantaBeahavior adecuado, null si no ha encontrado ninguno.</returns>
    public PlantaBehaviour GetGrownPlant()
    {
        PlantaBehaviour planta = null;
        List<PlantaBehaviour> plantasGrowadas = new List<PlantaBehaviour>();
        for( int c= 0; c < plantas.Count; c++)
        {
            //Debug.Log(plantas[c].GetPlantState().ToString());
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
