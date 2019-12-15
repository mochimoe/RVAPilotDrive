using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is used to give a health in object.
 */

public class CharacterHealth : MonoBehaviour
{
    // this variable contain player health, the private must have value between 0 and 1
    public float health; 
    private float playerHealth;

    public AudioClip warningSound;
    private AudioSource audioSource;
    private bool playSound = true;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        playerHealth = 1f;
    }

    private void Update() {
        if(playerHealth <= 0.5f && playSound)
        {
            Debug.Log("play health");

            audioSource.PlayOneShot(warningSound, 1f);

            playSound = false;
        }

        if(playerHealth > 0.5f)
        {
            playSound = true;
        }
    }

    // this method is used for gaining health
    public void gainHealth(float healthGained)
    {
        float calculateHealth = healthGained / this.health;

        if(this.playerHealth + calculateHealth >= 1f)
        {
            this.playerHealth = 1f;
        }
        else
        {
            this.playerHealth += calculateHealth;
        }
    }

    // this method is used to reduce player health
    public void reduceHealth(float healthReduced)
    {
        this.playerHealth -= healthReduced / this.health;
    }

    // this method is used to get player health
    public float getPlayerHealth()
    {
        return this.playerHealth;
    }
}
