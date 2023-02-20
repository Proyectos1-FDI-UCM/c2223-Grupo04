using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilComponent : MonoBehaviour
{
    public enum TipoCreciminto
    {
        rapido,
        lento
    }

    [SerializeField]
    [Tooltip("El tipo de soil, que determina la velocidad de crecimiento de las plantas")]
    private TipoCreciminto tipoCreciminto;
}
