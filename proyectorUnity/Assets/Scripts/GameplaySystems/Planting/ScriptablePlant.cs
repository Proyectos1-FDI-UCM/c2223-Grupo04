using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantaData", menuName = "ScriptableObjects/PlantaScriptableObject", order = 1)]

public class ScriptablePlant : ScriptableObject
{
    public float GrowSpeed;
    public float DrySpeed;

    public Sprite[] GrowingSprite = new Sprite[3];
    

}
