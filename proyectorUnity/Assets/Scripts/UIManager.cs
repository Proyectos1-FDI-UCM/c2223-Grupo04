using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameManager;

public class UIManager : MonoBehaviour
{
    float _time;

    [SerializeField] TextMeshProUGUI _contador;
    [SerializeField] GameObject _introUI, _gameUI, _pausaUI, _winUI, _tutorialUI;
    [SerializeField] Image _inventory;
    [SerializeField] GameObject _prefabObjetivo;
    [SerializeField] Transform _panel3;
    [SerializeField]
    List<GameObject> _insPrefObjs; //Contiene las instacias de los prefabs de los objetivos.
    public NivelObjetivos objetivosnivel;


    public static UIManager Instance; //Para el singletone.

    // Start is called before the first frame update
    void Start()
    {
        _inventory.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > 0)
        {
            _contador.text = (int)(_time / 60) + ":" + (int)(_time % 60);
            _time = _time - Time.deltaTime;
        }
        else _contador.text = "00:00"; //Cuando acaba el contador y el tornado esta en juego ponemos esto por ejemplo.
    }
    private void Awake() //Para el singletone.
    {
        this.enabled = true;
        Instance = this;
    }

    #region methods
    public void NuevoTiempoDeTornado() //Es llamado por el GameManager para coger el nuevo tiempo del nuevo tornado.
    {
        _time = GameManager.Instance._tornadoSpawner._tMul + GameManager.Instance._tornadoSpawner._tEntreTornados;
    }
    public void changeInventory(GameObject tool)
    {
        if (tool != null)
        {
            _inventory.enabled = true;
            _inventory.sprite = tool.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            _inventory.enabled = false; //desativamos el inventory para que no aparezca algo cuando se deja la herramienta o se usa la semilla.
        }
    }
    public void SetearObjetivos(NivelObjetivos objetivosNivel)
    {
        //Debug.Log("Seteado antes del bucle.");
        for (int i = 0; i < objetivosNivel.plantas.Length; i++)
        {
            GameObject objetivoUI = GameObject.Instantiate(_prefabObjetivo, _panel3);
            //Debug.Log(objetivoUI.name);
            _insPrefObjs.Add(objetivoUI); //Añadimos a la lista el objetivo.

            Image icono = objetivoUI.GetComponent<ReferenciaUIObjetivos>().DevolverImagen();
            TextMeshProUGUI txtinvariable = objetivoUI.GetComponent<ReferenciaUIObjetivos>().DevolverTxtInvariable();

            icono.sprite = objetivosNivel.plantas[i].icono;
            txtinvariable.text = "/ " + objetivosNivel.cantidad[i]; //Si sumas algo a un string todo se convierte a string.
            //Debug.Log("Seteado en el bucle al final.");
        }
        //Debug.Log("Seteado despues del bucle.");
    }
    public void UpdatearObjetivosUI(int progreso, int index)
    {
        TextMeshProUGUI variable = _insPrefObjs[index].GetComponent<ReferenciaUIObjetivos>().DevolverTxtVariable();
        variable.text = progreso.ToString();

    }
    public void CambiarUISegunEstadoJuego()
    {
        if (GameManager.Instance._state == GameManager.GameStates.INTRO)
        {
            if (_panel3.childCount <= 0) SetearObjetivos(objetivosnivel);
            _introUI.SetActive(true);
            _gameUI.SetActive(false);
            _winUI.SetActive(false);
            _pausaUI.SetActive(false);
            if (_tutorialUI != null) _tutorialUI.SetActive(false);
        }
        else if (GameManager.Instance._state == GameManager.GameStates.TUTORIAL)
        {
            _introUI.SetActive(false);
            _gameUI.SetActive(true);
            _winUI.SetActive(false);
            _pausaUI.SetActive(false);
        }
        else if (GameManager.Instance._state == GameManager.GameStates.GAME)
        {
            _introUI.SetActive(false);
            _gameUI.SetActive(true);
            _winUI.SetActive(false);
            _pausaUI.SetActive(false);
            if (_tutorialUI != null) _tutorialUI.SetActive(false);
        }
        else if (GameManager.Instance._state == GameManager.GameStates.WIN)
        {
            _introUI.SetActive(false);
            _gameUI.SetActive(false);
            _winUI.SetActive(true);
            _pausaUI.SetActive(false);
        }/*
        else if (GameManager.Instance._state == GameManager.GameStates.PAUSA) 
        {
            _introUI.SetActive(false);
            _gameUI.SetActive(false);
            _winUI.SetActive(false);
            _pausaUI.SetActive(true);
        }*/
    }
    public void Pausar()
    {
        _introUI.SetActive(false);
        _gameUI.SetActive(false);
        _winUI.SetActive(false);
        _pausaUI.SetActive(true);
    }
    public void ContinuarBoton()
    {
        Time.timeScale = 1; //Volver a correr el tiempo.
        _gameUI.SetActive(true);
        _pausaUI.SetActive(false);
    }
    public void SalirBoton(int id)
    {
        Time.timeScale = 1; //Volver a correr el tiempo.
        SceneManager.LoadScene(id);
    }

    #region cosas tutorial
    public void TextoTutorial(string _texto, float time)
    {
        _tutorialUI.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = _texto;
        _tutorialUI.SetActive(true);

        //Invoke("QuitarTextoTutorial", time);
    }

    private void QuitarTextoTutorial()
    { _tutorialUI.SetActive(false); }

    public void FinalTextoTutorial(string _texto)
    {
        _introUI.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = _texto;
    }
    #endregion
    #endregion
}
