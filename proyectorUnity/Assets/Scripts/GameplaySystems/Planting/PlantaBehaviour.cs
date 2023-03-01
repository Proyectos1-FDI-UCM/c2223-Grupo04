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
    private LevelManager _levelManager;
    //Variables de control de crecimiento (temporizador)
    private float growTimer;
    private float dryTimer;

    private enum PlantState
    {
        Growing,
        GrowingWatered,
        Drying,
        Dead
    }

    private PlantState _plantState;
    private int _currentGrowSprite, _currentDrySprite;


    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GameManager.Instance._levelManager;
        GrowSprite(0);

        _plantState = PlantState.Growing;
        fertileMultiplier = 0.8f;
        GrowSprite(0);
        _currentDrySprite = -1;

        if (_isSoilFertile) growTimer = _plantData.GrowSpeed * fertileMultiplier;  //tenenmos en cuenta si el soil es fertil
        else growTimer = _plantData.GrowSpeed;

        dryTimer = _plantData.DrySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_plantState == PlantState.Growing || _plantState == PlantState.GrowingWatered) 
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
                _plantState = PlantState.Drying;
                _levelManager.PlantHasGrown(_plantData);
            }


        }

        else if (!_isSoilFertile && _plantState == PlantState.Drying)
        {
            dryTimer -= Time.deltaTime;

            if (dryTimer <= (_plantData.DrySpeed / 3) * 2 && _currentDrySprite < 0)
            {
                DrySprite(0);

            }

            else if (dryTimer <= _plantData.DrySpeed / 3 && _currentGrowSprite < 1)
            {
                DrySprite(1);

            }

            else if (dryTimer < 0)
            {
                DrySprite(2);
                _levelManager.PlantDied(_plantData);
                _plantState = PlantState.Dead;
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

    public void GetWatered()
    {
        if (_plantState == PlantState.Growing)
        {
            _plantState = PlantState.GrowingWatered;
            growTimer = growTimer * 0.8f;
        }


        else if (_plantState == PlantState.Drying)
        {
            GrowSprite(3);
            _currentDrySprite = -1;
            dryTimer = _plantData.DrySpeed;

        }

    }
} 

