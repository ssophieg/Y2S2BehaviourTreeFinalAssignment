using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{

    public GameObject ninjaOpponent;
    public GameObject mageOpponent;

    public Transform spawnpointLeft;
    public Transform spawnpointRight;
    Transform spawnpointCenter;

    Vector3 LeftVector;
    Vector3 RightVector;
    Vector3 CenterVector;

    float timer = 0;

    float currentTransform = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnpointCenter = transform;

        LeftVector = spawnpointLeft.position;
        RightVector = spawnpointRight.position;
        CenterVector = spawnpointCenter.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            switch (currentTransform) 
            {
                case 1:
                    Instantiate(mageOpponent, CenterVector, Quaternion.Euler(0, -90, 0));
                    currentTransform += 1;
                    break;
                case 2:
                    Instantiate(mageOpponent, RightVector, Quaternion.Euler(0, -90, 0));
                    currentTransform += 1;
                    break;
                case 3:
                    Instantiate(mageOpponent, LeftVector, Quaternion.Euler(0, -90, 0));
                    currentTransform += 1;
                    break;
            }
            timer = 0;
        }

        if (currentTransform > 3)
        {
            currentTransform = 1;
        }
    }
}
