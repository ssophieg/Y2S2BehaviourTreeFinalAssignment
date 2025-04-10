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
        if (timerRun)
        {
            timer += Time.deltaTime;
        }

        scoreText.text = Mathf.Round(timer).ToString();
    }
}
