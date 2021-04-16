using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;

    private float elapsedTime;

    void Start()
    {
        timeCounter.text = "Time: 00:00";
        elapsedTime = 0f;
    }

    void Update()
    {
        if (!SceneManagement.gameIsPaused)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingString = "Time: " + timePlaying.ToString(@"mm\:ss");
            timeCounter.text = timePlayingString;
        }
        
    }
}
