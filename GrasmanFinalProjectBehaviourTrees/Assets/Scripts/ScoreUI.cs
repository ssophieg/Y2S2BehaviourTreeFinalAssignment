using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    float timer = 0;
    public TextMeshProUGUI scoreText;
    public bool timerRun = true;

    // Update is called once per frame
    void Update()
    {
        //if the game isnt over, keep the timer tunning
        if (timerRun)
        {
            timer += Time.deltaTime;
        }

        //change the score text UI to a rounded version of the timer
        scoreText.text = Mathf.Round(timer).ToString();
    }
}
