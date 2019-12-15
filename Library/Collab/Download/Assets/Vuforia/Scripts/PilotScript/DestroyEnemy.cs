using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private PlaneHealth planeHealth;
    private ScoreManager scoreManager;
    public int enemyDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        planeHealth = GameObject.FindObjectOfType<PlaneHealth>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider plane) {
        if(plane.gameObject.tag == "Player")
        {       
            planeHealth.health -= enemyDamage;
            Destroy(gameObject);
        }

        if(plane.gameObject.tag == "DestroyField")
        {
            scoreManager.updateScore(scoreManager.score);

            Destroy(gameObject);
        }
    }
}
