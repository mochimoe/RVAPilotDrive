using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function spawning powerups
 */

public class PowerManager : MonoBehaviour
{
    // other script references
    private CharacterHealth characterHealth;
    private TimeManager timeManager;

    // target parent location for spawn enemys
    private GameObject imageTarget;

    // this variable contain spawn location for spawning powerup
    public Transform[] spawnPoint;

    // wave component that contain powerups spawn and identity
    [System.Serializable]
    public class Wave 
    {
        public string name;
        public GameObject[] items;
        public float spawnTime;
    }
    public Wave[] waves;

    // variable that locate position of wave and time
    private int wavePosition;
    public int timePosition;

    // variable that contain rarety for powerup spawning
    public int spawnChance;
    public int[] newSpawnChance;

    // countdown for spawning powerup
    private float countDown;

    // this variable contain target powerup
    public GameObject plane;

    // this variable controlling stack for using powerup
    public int maxStack = 2;
    private int stackNow;

    // prevent overlap spawn component
    private int prevSpawnPosition;
    private int newPosition;

    // controlling activated spawn
    public bool canSpawn;
    
    // variable for controlling update status wave
    public bool canUpdateStatus;

    /**
        this variable contain time for update enemy speed each wave
        Note : the wave must be start from wave 2 not wave 1, so if you have 3 wave you must add change time 
               from wave 2 (same like Enemy Manager)
    */
    public int[] changeTime;
    
    // this variable detect enemy for updating Multiple Score powerup
    private GameObject[] enemy;

    private void Start() {
        characterHealth = GameObject.FindObjectOfType<CharacterHealth>();
        timeManager = GameObject.FindObjectOfType<TimeManager>();

        imageTarget = GameObject.FindWithTag("ImageTarget");

        countDown = waves[wavePosition].spawnTime;
    }

    private void Update() {
        if(canSpawn)
        {
            countDown -= Time.deltaTime;

            if(countDown <= 0)
            {
                calculateChance();

                countDown = waves[wavePosition].spawnTime;
            }
        }

        if(canUpdateStatus)
        {
            updateWave();
        }
    }

    // this method doing the proses of spawning and prevent the spawn overlap
    private void preventOverlap()
    {
        do
        {
            newPosition = Random.Range(0, spawnPoint.Length);
        } while (prevSpawnPosition == newPosition);

        int positionItem = Random.Range(0, waves[wavePosition].items.Length);

        Instantiate(waves[wavePosition].items[positionItem], spawnPoint[newPosition].position, 
                    Quaternion.identity, imageTarget.transform);
    }

    // invulnerable powerup
    public void invulnerable(string tagName)
    {
        plane.gameObject.tag = tagName;
    }

    // Heal powerup
    public void heal(float healAmount)
    {
        characterHealth.gainHealth(healAmount);
    }

    // Multiply score powerup
    public void multiplyingScore(int multipleAmount)
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemies in enemy)
        {
            enemies.GetComponent<CharacterController>().multiplyingScore(multipleAmount);
        }
    }

    // check status stack powerup
    public bool getStackStatus()
    {
        if(stackNow != maxStack)
        {
            return true;
        }

        return false;
    }

    // set stack powerup
    public void setStack(int stack)
    {
        stackNow += stack;
    }

    // calculate spawn rarety
    public void calculateChance()
    {
        int calculate = Random.Range(0, 101);

        if(calculate <= spawnChance)
        {
            int totalChance = 0;

            for(int i = 0; i < waves[wavePosition].items.Length; i++)
            {
                totalChance += waves[wavePosition].items[i].GetComponent<SpawnRarety>().rarety;
            }

            int randomChance = Random.Range(0, totalChance);

            for(int i = 0; i < waves[wavePosition].items.Length; i++)
            {
                int itemRarety = waves[wavePosition].items[i].GetComponent<SpawnRarety>().rarety;

                if(randomChance <= itemRarety)
                {
                    preventOverlap();

                    break;
                }
                else
                {
                    randomChance -= waves[wavePosition].items[i].GetComponent<SpawnRarety>().rarety;
                }
            }
        }
    }

    // update wave and time position
    public void updateWave()
    {
        if(changeTime[timePosition] == (int)timeManager.getCounter())
        {
            Debug.Log("Updating");

            if(wavePosition+1 < waves.Length)
            {
                wavePosition++;
            }
            else
            {
                canUpdateStatus = false;
            }

            if(timePosition+1 < changeTime.Length)
            {
                timePosition++;
            }

            spawnChance = newSpawnChance[timePosition];
        }
    }
}
