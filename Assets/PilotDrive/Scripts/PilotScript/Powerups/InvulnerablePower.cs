using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script have function controlling the powerup invurnerable
 */

public class InvulnerablePower : MonoBehaviour
{
    // other script references
    private PowerManager powerManager;
    private UsePowerups usePowerups;

    // variable that contain spawn parent for particle effect
    private GameObject spawnParent;

    // variable that contain tag for opperating invulnerable powerup
    private string powerTag = "Invulnerable";
    private string normalTag = "Player";

    // variable that contain particle effect for destroy
    public GameObject destroyParticle;
    
    // this variable used for powerup duration
    public float waitDuration;

    private void Start() {
        powerManager = GameObject.FindObjectOfType<PowerManager>();
        usePowerups = GameObject.FindObjectOfType<UsePowerups>();

        spawnParent = GameObject.FindWithTag("ImageTarget");
    }

    private void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player" && powerManager.getStackStatus())
        {
            usePowerups.invurnerable = true;

            powerManager.setStack(1);

            StartCoroutine(runInvulnerable(waitDuration));
        }
        else if(player.gameObject.tag == "Invulnerable")
        {
            Destroy(gameObject);
        }
    }

    // this method have function to process the powerup
    IEnumerator runInvulnerable(float waitDuration)
    {
        powerManager.invulnerable(powerTag);

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(waitDuration);

        powerManager.invulnerable(normalTag);

        powerManager.setStack(-1);
        
        Instantiate(destroyParticle, transform.position, transform.rotation, spawnParent.transform);

        usePowerups.invurnerable = false;

        Destroy(gameObject);
    }
}
