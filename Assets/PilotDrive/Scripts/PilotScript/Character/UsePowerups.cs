using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to give object ability using powerups
 */

public class UsePowerups : MonoBehaviour
{
    // this variable contain powerup status being used or not
    public bool invurnerable, heal, multiplyScore;

    // this variable contain particle effect for invulnerable powerup
    public ParticleSystem invurParticleFirstUse;
    public ParticleSystem invurParticleUse;
    public ParticleSystem invurParticleEndUse;

    // effect for invurnerable powerup
    private enum InvurStatus {FirstUse, SecondUse, FinalUse}
    private InvurStatus invurStatus = InvurStatus.FirstUse;
    
    // Update is called once per frame
    void Update()
    {
        if(invurnerable)
        {
            if(invurStatus == InvurStatus.FirstUse)
            {
                invurParticleFirstUse.Play();

                gameObject.GetComponent<SphereCollider>().enabled = true;

                invurStatus = InvurStatus.SecondUse;
            }
            else if(invurStatus == InvurStatus.SecondUse && !invurParticleFirstUse.isPlaying)
            {
                invurParticleUse.Play();

                invurStatus = InvurStatus.FinalUse;
            }
        }
        else if (invurStatus == InvurStatus.FinalUse && !invurnerable)
        {
            invurParticleUse.Stop();

            invurParticleEndUse.Play();

            invurStatus = InvurStatus.FirstUse;
        }
        else
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider powerup) {
        if(powerup.gameObject.CompareTag("UseInvurnerable"))
        {
            invurnerable = true;
        }
    }
}
