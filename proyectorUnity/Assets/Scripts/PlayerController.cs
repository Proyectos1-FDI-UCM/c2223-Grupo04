using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Instancia del PlayerController
    /// </summary>
    public static PlayerController Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

}
