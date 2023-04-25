using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Animator _transition;
    //SOUNDS
    [SerializeField]
    MenuSounds _menuSounds;

    private void Start()
    {
        _menuSounds = GetComponent<MenuSounds>();
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);
    }

    #region methods
    public void PlayBoton()
    {
        StartCoroutine(LoadLevel(1));
        _menuSounds.ButtonSound();
    }
    public void MenuBoton()
    {
        // Not yet
    }
    public void ExitBoton()
    {
        Application.Quit();
        _menuSounds.ButtonSound();
    }
    #endregion
}
