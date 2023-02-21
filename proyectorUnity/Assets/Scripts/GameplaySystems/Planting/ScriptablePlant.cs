using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantaData", menuName = "ScriptableObjects/PlantaScriptableObject", order = 1)]

public class ScriptablePlant : ScriptableObject
{
    public float GrowSpeed; //Tiempo máximo de crecimiento
    public float DrySpeed; ////Tiempo máximo de secado

    public Sprite[] GrowingSprite = new Sprite[3];

    public Sprite[] DryingSprite = new Sprite[3];
    

}
