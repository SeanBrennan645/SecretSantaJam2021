using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string SceneToChangeTo;
    [SerializeField] string CurrentScene;
    [SerializeField] string PreviousScene;

    //script could be better done

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneToChangeTo);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(PreviousScene);
    }
}
