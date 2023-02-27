using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NivelObjetivos", menuName = "ScriptableObjects/ObjetivoScriptableObject", order = 2)]

public class NivelObjetivos : ScriptableObject
{
    public ScriptablePlant[] plantas;
    public int[] cantidad;
}
