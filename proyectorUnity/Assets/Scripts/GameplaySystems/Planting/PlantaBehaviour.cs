using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaBehaviour : MonoBehaviour
{

    public ScriptablePlant PlantaData;

    [HideInInspector]
    public bool _isSoilFertile;


    //Variables de control de crecimiento (temporizador)
    public float growTimer;
    public float dryTimer;
    public bool maxTime = false;
    public bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        growingSprite(0);
        growTimer = PlantaData.GrowSpeed;
        dryTimer = PlantaData.DrySpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (growTimer > 0f)
        {
            growTimer -= Time.deltaTime;
            if (growTimer <= (PlantaData.GrowSpeed / 3) * 2) growingSprite(1);
            else if (growTimer <= PlantaData.GrowSpeed / 3) growingSprite(2);
        }
        else if (!maxTime) 
        {
            growingSprite(3); maxTime = true; //Último Sprite de crecimiento y establecimiento de la condición de inicio de secado "maxTime"
        }  
        else
        {
            if (maxTime == true)
            {
                dryTimer -= Time.deltaTime;
                if (dryTimer <= (PlantaData.DrySpeed / 3) * 2) dryingSprite(0);
                else if (growTimer <= PlantaData.DrySpeed / 3) dryingSprite(1);
            }
            else dryingSprite(2); death = true;  //Último Sprite de secadoy establecimiento de la condición de muerte "death"
        }
    }
    private void growingSprite(int gsprite = 0)
    {
        GetComponent<SpriteRenderer>().sprite = PlantaData.GrowingSprite [gsprite];  //Referencia al Sprite Renderer para establecer los sprites de crecimiento
    }
    private void dryingSprite(int dsprite = 0)
    {
        GetComponent<SpriteRenderer>().sprite = PlantaData.DryingSprite[dsprite];  //Referencia al Sprite Renderer para establecer los sprites de secado
    }
} 

