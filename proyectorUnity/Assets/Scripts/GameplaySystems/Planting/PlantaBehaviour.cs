using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaBehaviour : MonoBehaviour
{

    private ScriptablePlant _plantData;

    [HideInInspector]
    private bool _isSoilFertile;
    [SerializeField]
    Animator _anim;
    [SerializeField]
    [Tooltip("Valor por el que multiplicar el crecimiento en caso de ser soil fertil")]
    private float fertileMultiplier;
    private LevelManager _levelManager;
    //Variables de control de crecimiento (temporizador)
    private float growTimer, dryTimer;
    private int _currentGrowSprite, _currentDrySprite;

    public enum PlantState
    {
        Growing,
        GrowingWatered,
        Drying,
        Dead
    }
    private PlantState _plantState;


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
        /*
        if (GameManager.Instance._lluviaFloja) 
        {
            GetWatered();
            print("Llueve sobre recién plantado");
        }*/
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
                gameObject.transform.GetChild(1).gameObject.SetActive(false); //Desactivar las particulas de regado.
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

            else if (dryTimer <= (_plantData.DrySpeed / 3) && _currentDrySprite < 1)
            {
                DrySprite(1);

            }

            else if (dryTimer < 0)
            {
                DrySprite(2);
                _plantState = PlantState.Dead;
                _levelManager.PlantaSeca(this);
            }

        }

    }
    /// <summary>
    /// Configura el tipo de planta al ser creada.
    /// </summary>
    /// <param name="plantData">El tipo de planta</param>
    public void SetUpPlant(ScriptablePlant plantData) { _plantData = plantData; }

    /// <summary>
    /// Set the fertile to the indicated value
    /// </summary>
    /// <param name="isSoilFertil">Indica si el soil es fertil</param>
    public void SetFertil(bool isSoilFertil) { _isSoilFertile = isSoilFertil; }

    private void GrowSprite(int _desiredSprite)
    {
        _currentGrowSprite = _desiredSprite;
        _anim.gameObject.GetComponent<SpriteRenderer>().sprite = _plantData.GrowingSprite[_currentGrowSprite];
    }

    private void DrySprite(int _desiredSprite)
    {
        _currentDrySprite = _desiredSprite;
        _anim.gameObject.GetComponent<SpriteRenderer>().sprite = _plantData.DryingSprite[_currentDrySprite];
    }

    /// <summary>
    /// Riega la planta. Aplicando los distintos calculos y lógicas pertinentes.
    /// </summary>
    public void GetWatered()
    {
        if (_plantState == PlantState.Growing)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true); // Activar las particulas de regado.
            _plantState = PlantState.GrowingWatered;
            growTimer = growTimer * 0.8f;
            Debug.Log("Regado");
        }


        else if (_plantState == PlantState.Drying)
        {
            GrowSprite(3);
            _currentDrySprite = -1;
            dryTimer = _plantData.DrySpeed;

        }

    }

    /// <summary>
    /// Quita la planta, llamando al level manager y destruyendo el propio gameObject.
    /// </summary>
    public void RemovePlant()
    {        
        _levelManager.RemovePlant(this);
        Destroy(gameObject);
    }

    public PlantState GetPlantState()
    {
        return _plantState;
    }

    public ScriptablePlant GetPlantData()
    {
        return _plantData;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _anim.SetTrigger("move");
    }
} 

