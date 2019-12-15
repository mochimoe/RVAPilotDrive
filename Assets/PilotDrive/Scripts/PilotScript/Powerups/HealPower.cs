using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to controll heal powerup
 */

public class HealPower : MonoBehaviour
{   
    // other script references
    private PowerManager powerManager;

    // variable is used to spawn the particle effect inside another gameObject
    private GameObject spawnParent;

    // the amount of healing power
    public float healAmount;

    public GameObject destroyParticle;

    // Start is called before the first frame update
    void Start()
    {
        powerManager = GameObject.FindObjectOfType<PowerManager>();
        spawnParent = GameObject.FindWithTag("ImageTarget");
    }

    private void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player" || player.gameObject.tag == "Invulnerable")
        {
            if(powerManager.getStackStatus())
            {  
                powerManager.setStack(1);

                powerManager.heal(healAmount);

                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;

                powerManager.setStack(-1);

                Instantiate(destroyParticle, transform.position, transform.rotation, spawnParent.transform);

                Destroy(gameObject);
            }
        }
    }
}
