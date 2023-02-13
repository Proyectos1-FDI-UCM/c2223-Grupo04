using UnityEngine;

public class Planta : ScriptableObject
{
    [SerializeField]
    //Velocidad a la que la planta crece
    private float velCrecimiento;
    [SerializeField]
    //Velocidad a la que la planta se seca
    private float velSecado;
    [SerializeField]
    //Entidad propia en el juego
    private GameObject objeto;
}