using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

using NodeCanvas.Tasks.Actions;

public class HealingCooldown : MonoBehaviour
{
    public float cooldownTimer = 0;
    float timerRunning = 0;

    public Slider cooldownUI;

    public GameObject readyText;
    public GameObject gameOverText;
    public GameObject restartButton;

    public ScoreUI scoreUI;

    public TakeDamage frontliner1;
    public TakeDamage frontliner2;
    public TakeDamage frontliner3;
    public TakeDamage player;

    float dealDamageAmount = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime * timerRunning;
        if(cooldownTimer <= 0)
        {
            timerRunning = 0;
            readyText.SetActive(true);
        }
        else
        {
            timerRunning = 1;
            readyText.SetActive(false);
        }

        cooldownUI.value = cooldownTimer;

        if (player.alive == false || frontliner1.alive == false || frontliner2.alive == false || frontliner3.alive == false)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            scoreUI.timerRun = false;

            if (dealDamageAmount < 12)
            {
                player.SendMessage("ReceiveDamage");
                frontliner1.SendMessage("ReceiveDamage");
                frontliner2.SendMessage("ReceiveDamage");
                frontliner3.SendMessage("ReceiveDamage");

                dealDamageAmount += 1;
            }
        }
    }
}
