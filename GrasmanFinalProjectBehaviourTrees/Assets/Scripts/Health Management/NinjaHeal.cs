using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaHeal : MonoBehaviour
{
    public GameObject healthBar;

    public Material greenColour;
    public Material defaultColour;

    float flashTimer;
    bool flashing = false;

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
    }
    private void HealDamage()
    {
        flashing = true;
        gameObject.GetComponent<MeshRenderer>().material = greenColour;

        healthBar.transform.localScale += new Vector3(0, 0, 0.3f);

        if (healthBar.transform.localScale.z > 0.3)
        {
            healthBar.GetComponent<MeshRenderer>().material = greenColour;
        }

    }
}
