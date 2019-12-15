using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerBackup : MonoBehaviour
{
    private TimeManager timeManager;

    public Transform imageTarget;

    [System.Serializable]
    public class Wave {
        public string name = "Wave";
        public GameObject[] enemy;
        public float[] newEnemySpeed;
        public float spawnTime;
        public float spawnRate;
    }

    public Wave[] waves;

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
            InvokeRepeating("spawningEnemy", waves[wavePosition].spawnTime, waves[wavePosition].spawnRate);
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
        int enemyPosition = Random.Range(0, waves[wavePosition].enemy.Length);

        Instantiate(waves[wavePosition].enemy[enemyPosition], spawnPoint[spawnPosition].position, 
                    waves[wavePosition].enemy[enemyPosition].transform.rotation, imageTarget);

        // Debug.Log("Spawn Cube " + enemyPosition);
    }

    public void updateSpawning()
    {
        if((int)timeManager.getCounter() == changeTime[timePosition])
        {
            Debug.Log(waves[wavePosition].name);
            
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
        
            startSpawning = true;
            
            // change enemy speed
            for(int enemyPosition = 0; enemyPosition < waves[wavePosition].enemy.Length; enemyPosition++)
            {
                waves[wavePosition].enemy[enemyPosition].GetComponent<EnemyMovement>().enemySpeed = 
                    waves[wavePosition].newEnemySpeed[enemyPosition]*-1f;
            }
        }
    }
}
