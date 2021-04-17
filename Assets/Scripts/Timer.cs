using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Classe respons�vel pelo timer
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;

    private float elapsedTime;

    // Inicia o timer com 0 segundos
    void Start()
    {
        timeCounter.text = "00:00";
        elapsedTime = 0f;
    }

    // Se o jogo n�o tiver pausado, o timer � incrementado
    void Update()
    {
        if (!SceneManagement.gameIsPaused)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingString = timePlaying.ToString(@"mm\:ss");
            timeCounter.text = timePlayingString;
        }
        
    }
}
