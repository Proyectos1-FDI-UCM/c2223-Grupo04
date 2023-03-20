using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ResumenNivel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _nombre;
    [SerializeField]
    TextMeshProUGUI _tornados;
    [SerializeField]
    TextMeshProUGUI _secas;
    [SerializeField]
    Image _npc;

    public void UpdateResumen(string nombre, int tornados, int secas, Sprite npc)
    {
        _nombre.text = "Jardín de: " + nombre;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
