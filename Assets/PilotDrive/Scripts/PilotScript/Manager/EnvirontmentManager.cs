using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirontmentManager : MonoBehaviour
{
    /*
        this script is used for spawning cloud
     */

    // other script references
    private ObjectPooler objectPooler;
    
    // this variable is used for spawing cloud
    public Transform spawnPoint;
    public float spawnTime = 2f;
    private float countDown;

    // variable is used for spawn condition
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

    // this method have function to call cloud from object pooler
    public void spawnCloud()
    {
        objectPooler.spawnFromPool("cloud", spawnPoint.position);
    }
}
