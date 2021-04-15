using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        Resume();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        Pause();
    }
}
