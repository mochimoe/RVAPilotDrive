using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private TimeManager timeManager;

    public Transform imageTarget;

    [System.Serializable]
    public class Enemies {
        public string name = "Wave";
        public GameObject[] enemy;
        public float[] newEnemySpeed;
        public float spawnTime;
        public float spawnRate;
    }

    public Enemies[] enemies;

    public int[] changeTime;
    private int wavePosition = 0;
    private int timePosition = 0;

    public Transform[] spawnPoint;

    public bool stopSpawing;
    public bool startSpawning;
    private bool canUpdateStatus = true;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startSpawning)
        {     
            InvokeRepeating("spawningEnemy", enemies[wavePosition].spawnTime, enemies[wavePosition].spawnRate);
            startSpawning = false;
        }

        if(stopSpawing)
        {
            CancelInvoke();
            stopSpawing = false;
        }

        if(canUpdateStatus)
        {
            updateSpawning();
        }
    }

    void spawningEnemy()
    {
        int spawnPosition = Random.Range(0, spawnPoint.Length);
        int cubePosition = Random.Range(0, enemies[wavePosition].enemy.Length);

        Instantiate(enemies[wavePosition].enemy[cubePosition], spawnPoint[spawnPosition].position, 
                    spawnPoint[spawnPosition].rotation, imageTarget);

        Debug.Log("Spawn Cube " + cubePosition);
    }

    public void updateSpawning()
    {
        if((int)timeManager.getCounter() == changeTime[timePosition])
        {
            Debug.Log(enemies[wavePosition].name);
            
            if(wavePosition+1 < enemies.Length)
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
        
            startSpawning = true;
            
            // change enemy speed
            for(int enemyPosition = 0; enemyPosition < enemies[wavePosition].enemy.Length; enemyPosition++)
            {
                enemies[wavePosition].enemy[enemyPosition].GetComponent<EnemyMovement>().enemySpeed = 
                    enemies[wavePosition].newEnemySpeed[enemyPosition]*-1f;
            }
        }
    }
}
