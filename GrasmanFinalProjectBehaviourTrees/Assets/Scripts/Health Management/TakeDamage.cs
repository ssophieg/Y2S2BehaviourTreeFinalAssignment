using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public GameObject healthBar;

    public Material redColour;
    public Material defaultColour;

    float flashTimer;
    bool flashing = false;

    public bool alive = true;

    //is the death animation playing?
    bool deathAnim = false;

    //does this character take damage when clicked? (use for ninja characters)
    public bool takeDamageOnClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Flash character red upon taking damage
        if (flashing)
        {
            flashTimer += Time.deltaTime;
        }

        if (flashTimer > 0.4)
        {
            flashing = false;
            gameObject.GetComponent<MeshRenderer>().material = defaultColour;
            flashTimer = 0;
        }

        //if character dies, shrink model and then destroy gameobject
        if (alive == false && deathAnim == true)
        {
            gameObject.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            if (gameObject.transform.localScale.x <= 0)
            {
                deathAnim = false;

                Destroy(healthBar);
                GetComponentInParent<BehaviourTreeOwner>().gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void ReceiveDamage()
    {
        //red flash to indicate damage
        flashing = true;
        gameObject.GetComponent<MeshRenderer>().material = redColour;

        if (alive)
        {
            //shrink health bar
            healthBar.transform.localScale -= new Vector3(0, 0, 0.1f);
        }

        //turn health bar red when health is low
        if (healthBar.transform.localScale.z <= 0.3)
        {
            healthBar.GetComponent<MeshRenderer>().material = redColour;
        }

        //if health is 0, character is dead
        if (healthBar.transform.localScale.z <= 0)
        {
            alive = false;
            deathAnim = true;
        }
    }

    private void OnMouseDown()
    {
        if (takeDamageOnClick)
        {
            ReceiveDamage();
        }
    }
}
