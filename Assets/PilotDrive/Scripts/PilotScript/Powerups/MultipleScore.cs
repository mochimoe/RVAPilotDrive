using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function controlling multiply score powerup
*/

public class MultipleScore : MonoBehaviour
{
    // other script references
    private PowerManager powerManager;
    
    // variable is used to spawn the particle effect inside another gameObject
    private GameObject spawnParent;

    public GameObject destroyParticle;

    // variable have function to give multiply value
    public int scoreMultiple = 1;
    public bool useMultipleScore = false;

    // this variable is used to add duration of powerup
    public float duration;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        powerManager = GameObject.FindObjectOfType<PowerManager>();
        spawnParent = GameObject.FindWithTag("ImageTarget");

        countDown = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(useMultipleScore)
        {
            countDown -= Time.deltaTime;

            powerManager.multiplyingScore(scoreMultiple);

            if(countDown <= 0)
            {
                countDown = duration;

                powerManager.setStack(-1);
                
                useMultipleScore = false;

                powerManager.multiplyingScore(1);
                
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider player) {
        if(player.gameObject.CompareTag("Player") && powerManager.getStackStatus() && !useMultipleScore)
        {
            powerManager.setStack(1);

            Instantiate(destroyParticle, transform.position, transform.rotation, spawnParent.transform);

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            useMultipleScore = true;
        }
    }
}
