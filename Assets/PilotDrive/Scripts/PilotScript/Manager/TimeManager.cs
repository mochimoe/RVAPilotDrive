using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is controlling time in the game, like play time, pause, and resume.
 */

public class TimeManager : MonoBehaviour
{
    // other sctipt references
    private EnemyManager enemyManager;
    private PowerManager powerManager;
    private EnvirontmentManager environtmentManager;
    private CloudLocation cloudLocation;
    private PlayerMovement playerMovement;

    // this variable have function controll time play
    private float counter;
    public bool startTime;

    // this variable is used to stop cloud and emeny movement while pause and resume
    private GameObject[] enemies;
    private GameObject[] clouds;

    // this variable is used to controll player movement button in canvas
    public GameObject[] buttonMovementPlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        powerManager = GameObject.FindObjectOfType<PowerManager>();
        environtmentManager = GameObject.FindObjectOfType<EnvirontmentManager>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

        cloudLocation = GameObject.FindObjectOfType<CloudLocation>();

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime)
        {
            time();
        }
    }

    // this method is counting the play time,
    public void time()
    {
        counter += Time.deltaTime;
    }

    // this method is used to get play time value
    public float getCounter()
    {
        return counter;
    }

    // this method is controlling pause in game
    public void pauseTime()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        clouds = GameObject.FindGameObjectsWithTag("Cloud");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().setSpeed(0f);
        }

        foreach (GameObject cloud in clouds)
        {
            cloud.GetComponent<CloudMovement>().setSpeed(0f);
        }

        buttonMovementPlayer[0].SetActive(false);
        buttonMovementPlayer[1].SetActive(false);

        playerMovement.stopMove();
        enemyManager.startSpawning = false;
        powerManager.canSpawn = false;
        environtmentManager.startSpawning = false;

        cloudLocation.canMove = false;

        startTime = false;
    }

    // this method is controlling resume in game
    public void resumeTime()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        clouds = GameObject.FindGameObjectsWithTag("Cloud");

        foreach (GameObject enemy in enemies)
        {
            float tempSpeed = enemy.GetComponent<EnemyMovement>().enemySpeed;

            enemy.GetComponent<EnemyMovement>().setSpeed(tempSpeed);
        }

        foreach (GameObject cloud in clouds)
        {
            float tempSpeed = cloud.GetComponent<CloudMovement>().getTempSpeed();

            cloud.GetComponent<CloudMovement>().setSpeed(tempSpeed);
        }

        buttonMovementPlayer[0].SetActive(true);
        buttonMovementPlayer[1].SetActive(true);

        enemyManager.startSpawning = true;
        powerManager.canSpawn = true;
        environtmentManager.startSpawning = true;

        cloudLocation.canMove = true;

        startTime = true;
    }
}
