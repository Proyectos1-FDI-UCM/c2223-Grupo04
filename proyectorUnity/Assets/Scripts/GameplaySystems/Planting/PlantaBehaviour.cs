using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaBehaviour : MonoBehaviour
{

    private ScriptablePlant _plantData;

    [HideInInspector]
    private bool _isSoilFertile;

    //Variables de control de crecimiento (temporizador)
    private float growTimer;
    private float dryTimer;
    private bool maxTime;
    private bool death;

    // Start is called before the first frame update
    void Start()
    {
        GrowingSprite(0);
        growTimer = _plantData.GrowSpeed;
        dryTimer = _plantData.DrySpeed;
        maxTime = false;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (growTimer > 0f)
        {
            growTimer -= Time.deltaTime;
            if (growTimer <= (_plantData.GrowSpeed / 3) * 2) GrowingSprite(1);
            else if (growTimer <= _plantData.GrowSpeed / 3) GrowingSprite(2);
        }
        else if (!maxTime) 
        {
            GrowingSprite(3); maxTime = true; //Último Sprite de crecimiento y establecimiento de la condición de inicio de secado "maxTime"
        }  
        else
        {
            if (maxTime == true)
            {
                dryTimer -= Time.deltaTime;
                if (dryTimer <= (_plantData.DrySpeed / 3) * 2) DryingSprite(0);
                else if (growTimer <= _plantData.DrySpeed / 3) DryingSprite(1);
            }
            else DryingSprite(2); death = true;  //Último Sprite de secadoy establecimiento de la condición de muerte "death"
        }
    }
    public void SetUpPlant(bool isSoilFertil, ScriptablePlant plantData)
    {
        _plantData = plantData;
        _isSoilFertile = isSoilFertil;
    }

    private void GrowingSprite(int gsprite = 0)
    {
        GetComponent<SpriteRenderer>().sprite = _plantData.GrowingSprite [gsprite];  //Referencia al Sprite Renderer para establecer los sprites de crecimiento
    }
    private void DryingSprite(int dsprite = 0)
    {
        GetComponent<SpriteRenderer>().sprite = _plantData.DryingSprite[dsprite];  //Referencia al Sprite Renderer para establecer los sprites de secado
    }
} 

