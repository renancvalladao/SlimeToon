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

    [SerializeField]
    private GameObject winMenuUI = null;

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        winMenuUI.SetActive(true);
        gameIsPaused = true;
        //Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        gameIsPaused = false;
        //Time.timeScale = 1;
        ResetGame();
    }

    public void LoadStage(string stage)
    {
        SceneManager.LoadScene(stage);
    }

    public void StageSelection()
    {
        if (gameIsPaused)
        {
            gameIsPaused = false;
            Time.timeScale = 1;
        }       
        SceneManager.LoadScene("StageSelection");
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

    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
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
        SceneManager.LoadScene("StageSelection");
    }

    void OnApplicationFocus(bool hasFocus)
    {
        Resume();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!gameIsPaused)
        {
            Pause();
        }
    }
}
