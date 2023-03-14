using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region methods
    public void PlayBoton()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void MenuBoton()
    {
        // Not yet
    }
    public void ExitBoton()
    {
        Application.Quit();
    }
    #endregion
}
