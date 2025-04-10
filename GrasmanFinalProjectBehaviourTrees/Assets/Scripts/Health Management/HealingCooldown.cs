using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HealingCooldown : MonoBehaviour
{
    public float cooldownTimer = 0;
    float timerRunning = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime * timerRunning;
        if(cooldownTimer <= 0)
        {
            timerRunning = 0;
        }
        else
        {
            timerRunning = 1;
        }
    }
}
