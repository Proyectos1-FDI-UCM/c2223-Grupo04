using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticulitas : MonoBehaviour
{
    [SerializeField] GameObject _particulita;
    public void ActivaParticulitas()
    {
        _particulita.gameObject.SetActive(true); //Activa las particulas. 
    }
    public void DesactivaParticulitas()
    {
        _particulita.gameObject.SetActive(false); //Desactiva las particulas.
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Rio")) DesactivaParticulitas();
    }
}
