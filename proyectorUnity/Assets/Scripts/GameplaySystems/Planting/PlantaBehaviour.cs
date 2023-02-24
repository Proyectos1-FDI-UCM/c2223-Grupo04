using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaBehaviour : MonoBehaviour
{

    private ScriptablePlant _plantData;

    [HideInInspector]
    private bool _isSoilFertile;
    [SerializeField]
    private float fertileMultiplier;

    //Variables de control de crecimiento (temporizador)
    private float growTimer;
    private float dryTimer;
    private bool _isGrowing;
    private int _currentGrowSprite, _currentDrySprite;

    // Start is called before the first frame update
    void Start()
    {
        _isGrowing = true;
        GrowSprite(0);

        _currentDrySprite = -1;
        _currentGrowSprite= -1;
        if (_isSoilFertile) growTimer = _plantData.GrowSpeed * fertileMultiplier;  //tenenmos en cuenta si el soil es fertil
        else growTimer = _plantData.GrowSpeed;

        dryTimer = _plantData.DrySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrowing) 
        {
            growTimer -= Time.deltaTime;

            if (growTimer <= (_plantData.GrowSpeed / 3) * 2 && _currentGrowSprite < 1)
            {
                GrowSprite(1);

            }

            else if (growTimer <= _plantData.GrowSpeed / 3 && _currentGrowSprite < 2)
            {
                GrowSprite(2);

            }

            else if (growTimer < 0)
            {
                GrowSprite(3);
                _isGrowing = false;
            }


        }

        else
        {
            dryTimer -= Time.deltaTime;

            if (dryTimer <= (_plantData.DrySpeed / 3) * 2 && _currentDrySprite < 0)
            {
                Debug.Log("AAAAAAA");
                DrySprite(0);

            }

            else if (dryTimer <= _plantData.DrySpeed / 3 && _currentGrowSprite < 1)
            {
                DrySprite(1);

            }

            else if (dryTimer < 0)
            {
                DrySprite(2);
            }

        }

    }

    public void SetUpPlant(bool isSoilFertil, ScriptablePlant plantData)
    {
        _plantData = plantData;
        _isSoilFertile = isSoilFertil;
    }

    private void GrowSprite(int _desiredSprite)
    {
        _currentGrowSprite = _desiredSprite;
        GetComponent<SpriteRenderer>().sprite = _plantData.GrowingSprite[_currentGrowSprite];
    }

    private void DrySprite(int _desiredSprite)
    {
        _currentDrySprite = _desiredSprite;
        GetComponent<SpriteRenderer>().sprite = _plantData.DryingSprite[_currentDrySprite];
    }
} 

