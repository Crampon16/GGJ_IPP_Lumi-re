using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class contains all the methods to move though levels.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // Cached reference
    GameSession gameStatus;

    public void LoadNextScene()
    {
        Debug.Log("Loading Next Scene");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0 || currentSceneIndex == 1)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else if (currentSceneIndex == 2)
            LoadStartScene();
    }

    public void LoadStartScene()
    {
        Debug.Log("Loading Starting Scene");
        SceneManager.LoadScene(0);

        // Reset game and score
        gameStatus = FindObjectOfType<GameSession>();
        gameStatus.ResetGame();
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
