using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class contains all the methods to move though levels.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("Loading Next Scene");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        Debug.Log("Loading Starting Scene");
        SceneManager.LoadScene(0);
    }

    public int GetIndexLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
