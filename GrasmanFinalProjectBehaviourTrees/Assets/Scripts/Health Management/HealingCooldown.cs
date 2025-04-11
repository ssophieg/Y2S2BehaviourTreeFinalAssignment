using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

using NodeCanvas.Tasks.Actions;

public class HealingCooldown : MonoBehaviour
{
    //cooldown
    public float cooldownTimer = 0;

    //is the timer running?
    float timerRunning = 0;

    public Slider cooldownUI;

    //text that appears when healing can be used
    public GameObject readyText;

    //objects that appear upon game over
    public GameObject gameOverText;
    public GameObject restartButton;

    //score value text
    public ScoreUI scoreUI;

    //all allies and player
    public TakeDamage frontliner1;
    public TakeDamage frontliner2;
    public TakeDamage frontliner3;
    public TakeDamage player;

    //amount of time take damage is called upon game over
    float dealDamageAmount = 0;

    // Update is called once per frame
    void Update()
    {
        //count down cooldown timer
        cooldownTimer -= Time.deltaTime * timerRunning;

        //stop timer if it hits 0
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

        //change slider UI to match cooldown timer
        cooldownUI.value = cooldownTimer;

        //if any ally dies, game over
        if (player.alive == false || frontliner1.alive == false || frontliner2.alive == false || frontliner3.alive == false)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);

            //stop timer
            scoreUI.timerRun = false;

            if (dealDamageAmount < 12)
            {
                //kill all allies
                player.SendMessage("ReceiveDamage");
                frontliner1.SendMessage("ReceiveDamage");
                frontliner2.SendMessage("ReceiveDamage");
                frontliner3.SendMessage("ReceiveDamage");

                dealDamageAmount += 1;
            }
        }
    }
}
