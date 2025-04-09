using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{

    public GameObject ninjaOpponent;
    public GameObject mageOpponent;

    GameObject currentMage;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(mageOpponent, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
