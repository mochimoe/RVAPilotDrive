using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirontmentManager : MonoBehaviour
{
    private ObjectPooler objectPooler;

    public Transform spawnPoint;
    public Transform imageTarget;
    public float spawnTime = 2f;
    public float spawnRate = 3f;
    private float countDown;

    public bool startSpawning;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        countDown = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(startSpawning)
        {   
            countDown -= Time.deltaTime;

            if(countDown <= 0)
            {
                spawnCloud();
                countDown = spawnTime;
            }
        }
    }

    public void spawnCloud()
    {
        objectPooler.spawnFromPool("cloud", spawnPoint.position, spawnPoint.rotation);
    }
}
