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

    //SOUNDS
    MenuSounds _menuSounds;

    private void Start()
    {
        _menuSounds = GetComponent<MenuSounds>();
    }

    public void UpdateResumen(string nombre, int tornados, int secas, Sprite npc)
    {
        _nombre.text = "Jardín de: " + nombre;
        _tornados.text = "Tornados: " + tornados;
        _secas.text = "Plantas Secadas: " + secas;
        _npc.sprite = npc;
    }

    public void Disable()
    {
        _menuSounds.ButtonSound();
        gameObject.SetActive(false);
        
    }

    private void Update()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    */}
}
