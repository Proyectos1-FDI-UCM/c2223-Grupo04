using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LvlSelPruebas : MonoBehaviour
{
    [SerializeField]
    Animator _transition;

    public void ContinuePrueba()
    {

    }

    public void ChangeLvl(int i)
    {
        StartCoroutine(LoadLevel(i));
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        Time.timeScale = 1;
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);
    }
}
