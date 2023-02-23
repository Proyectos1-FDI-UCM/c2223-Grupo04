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
        GrowingSprite(0);
        growTimer = PlantaData.GrowSpeed;
        dryTimer = PlantaData.DrySpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (growTimer > 0f)
        {
            growTimer -= Time.deltaTime;
            if (growTimer <= (PlantaData.GrowSpeed / 3) * 2) GrowingSprite(1);
            else if (growTimer <= PlantaData.GrowSpeed / 3) GrowingSprite(2);
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
                if (dryTimer <= (PlantaData.DrySpeed / 3) * 2) DryingSprite(0);
                else if (growTimer <= PlantaData.DrySpeed / 3) DryingSprite(1);
            }
            else DryingSprite(2); death = true;  //Último Sprite de secadoy establecimiento de la condición de muerte "death"
        }
    }
    private void GrowingSprite(int gsprite = 0)
    {
        GetComponent<SpriteRenderer>().sprite = PlantaData.GrowingSprite [gsprite];  //Referencia al Sprite Renderer para establecer los sprites de crecimiento
    }
    private void DryingSprite(int dsprite = 0)
    {
        GetComponent<SpriteRenderer>().sprite = PlantaData.DryingSprite[dsprite];  //Referencia al Sprite Renderer para establecer los sprites de secado
    }

    public void RemovePlant()
    {
        Destroy(gameObject);
    }
} 

