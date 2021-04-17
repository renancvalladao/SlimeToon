using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Classe responsável pelo estado da cena
public class SceneManagement : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField]
    private GameObject pauseMenuUI = null;

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        print("Won");
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            gameIsPaused = true;
            Time.timeScale = 0;
        }
        
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1;
        }
            
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Stage01");
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
