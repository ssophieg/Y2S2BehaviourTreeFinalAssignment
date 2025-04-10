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
    }
}
