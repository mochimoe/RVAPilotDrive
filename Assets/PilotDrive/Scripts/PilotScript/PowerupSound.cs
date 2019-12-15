using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is used to play the pickup powerup sound
*/

public class PowerupSound : MonoBehaviour
{
    public AudioSource pickupPowerup;

    private void OnTriggerEnter(Collider powerup) {
        if(powerup.gameObject.CompareTag("UseInvurnerable") || powerup.gameObject.CompareTag("UseHeal") || 
            powerup.gameObject.CompareTag("UseMultiplyScore"))
        {
            pickupPowerup.Play();
        }
    }
}
