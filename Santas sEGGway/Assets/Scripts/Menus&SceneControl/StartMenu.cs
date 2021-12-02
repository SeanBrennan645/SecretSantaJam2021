using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] SceneChanger sceneChanger = null;
    [SerializeField] GameObject howToPlayUI = null;
    [SerializeField] GameObject mainMenuUI = null;

    public void StartGame()
    {
        sceneChanger.LoadNextScene();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        mainMenuUI.SetActive(false);
        howToPlayUI.SetActive(true);
    }

    public void Back()
    {
        mainMenuUI.SetActive(true);
        howToPlayUI.SetActive(false);
    }
}
