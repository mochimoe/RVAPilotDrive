using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is controlling enemy spawn
 */

public class EnemyManager : MonoBehaviour
{
    // other script references
    private TimeManager timeManager;

    // target parent location for spawn enemys
    private GameObject imageTarget;

    // wave component that contain enemy spawn and identity
    [System.Serializable]
    public class Wave {
        public string name = "Wave";
        public GameObject[] enemy;
        public float[] newEnemySpeed;
        public float spawnTime;
    }
    public Wave[] waves;
    private float countDown;

    // variable that prevent spawn from overlap
    private int prevSpawnPoint;
    
    // variable that locate position of wave, time for update, enemy spawn position
    private int spawnPosition;
    private int wavePosition = 0;
    private int timePosition = 0;

    /**
        this variable contain time for update enemy speed each wave
        Note : the wave must be start from wave 2 not wave 1, so if you have 3 wave you must add change time 
               from wave 2 
    */
    public int[] changeTime;

    // this variable contain spawn location for spawning enemy
    public Transform[] spawnPoint;

    // this variable controll the enemy spawner and update enemy status
    public bool startSpawning;
    private bool canUpdateStatus = true;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
        countDown = waves[wavePosition].spawnTime;

        imageTarget = GameObject.FindWithTag("ImageTarget");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startSpawning)
        {   
            countDown -= Time.deltaTime;

            if(countDown <= 0)
            {
                spawningEnemy();

                countDown = waves[wavePosition].spawnTime;
            }
        }

        if(canUpdateStatus)
        {
            updateSpawning();
        }
    }

    // this method doing the proses of spawning and prevent the spawn overlap
    private void spawningEnemy()
    {
        do
        {
            spawnPosition = Random.Range(0, spawnPoint.Length);
            
        } while (prevSpawnPoint == spawnPosition && spawnPoint.Length > 1);

        prevSpawnPoint = spawnPosition;

        int enemyPosition = Random.Range(0, waves[wavePosition].enemy.Length);

        Instantiate(waves[wavePosition].enemy[enemyPosition], spawnPoint[spawnPosition].position, 
                    waves[wavePosition].enemy[enemyPosition].transform.rotation, imageTarget.transform); 
        
        if(wavePosition > 0)
        {
            StartCoroutine(increaseSpawn());
        }
    }

    // this method doing the proses updating enemy status like speed
    public void updateSpawning()
    {
        if((int)timeManager.getCounter() == changeTime[timePosition])
        {
            Debug.Log(waves[wavePosition].name);
            
            StartCoroutine(waitChangeWave());

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

            countDown = waves[wavePosition].spawnTime;
        }
    }

    /* 
        this method have function to increase the spawn enemy until wave position < 4
        if you had more wave you must add more spawnpoint to.
    */ 
    IEnumerator increaseSpawn()
    {
        yield return new WaitForSeconds(0.5f);

        if(wavePosition < 4)
        {
            for(int i = 0; i < wavePosition+1; i++)
            {
                int newSpawnPosition = Random.Range(0, spawnPoint.Length);
                int enemyPosition = Random.Range(0, waves[wavePosition].enemy.Length);

                Instantiate(waves[wavePosition].enemy[enemyPosition], spawnPoint[newSpawnPosition].position, 
                    waves[wavePosition].enemy[enemyPosition].transform.rotation, imageTarget.transform); 
            }
        }
        else
        {
            for(int i = 0; i < 4; i++)
            {
                int newSpawnPosition = Random.Range(0, spawnPoint.Length);
                int enemyPosition = Random.Range(0, waves[wavePosition].enemy.Length);

                Instantiate(waves[wavePosition].enemy[enemyPosition], spawnPoint[newSpawnPosition].position, 
                    waves[wavePosition].enemy[enemyPosition].transform.rotation, imageTarget.transform); 
            }
        }
    }

    // this method have function to give delay each wave
    IEnumerator waitChangeWave()
    {
        yield return new WaitForSeconds(2f);
    }
}
