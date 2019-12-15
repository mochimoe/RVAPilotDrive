using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to give the powerup time live
*/

public class PowerUpLife : MonoBehaviour
{
    // Other script references
    private UsePowerups usePowerups;

    // this enum used for the catagory powerup
    public enum Powerup{Heal, Invulnerable, MultipleScore}

    public Powerup powerUp = Powerup.Invulnerable;

    // this variable is used to give time live value
    public float timeLeft;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        usePowerups = GameObject.FindObjectOfType<UsePowerups>();

        countDown = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0 && powerUp == Powerup.Invulnerable)
        {
            InvulnerablePower status = gameObject.GetComponent<InvulnerablePower>();
            
            if(!usePowerups.invurnerable)
            {
                Destroy(gameObject);
            }
        }
        else if(countDown <= 0 && powerUp == Powerup.Heal)
        {
            Destroy(gameObject);
        }
        else if (countDown <= 0 && powerUp == Powerup.MultipleScore)
        {
            MultipleScore status = gameObject.GetComponent<MultipleScore>();

            if(!status.useMultipleScore)
            {
                Destroy(gameObject);
            }
        }
    }
}
