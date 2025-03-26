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

    bool alive = true;

    bool deathAnim = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if (alive == false && deathAnim == true)
        {
            gameObject.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            if (gameObject.transform.localScale.x <= 0)
            {
                deathAnim = false;
            }
        }
    }

    private void OnMouseDown()
    {
        //red flash to indicate damage
        flashing = true;
        gameObject.GetComponent<MeshRenderer>().material = redColour;

        if (alive)
        {
            //shrink health bar
            healthBar.transform.localScale -= new Vector3(0, 0, 0.1f);
        }

        if (healthBar.transform.localScale.z <= 0.3)
        {
            healthBar.GetComponent<MeshRenderer>().material = redColour;
        }

        if (healthBar.transform.localScale.z <= 0)
        {
            alive = false;
            deathAnim = true;
        }
    }
}
