using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is used to give a movement for enemy. but remember the direction of movement is decided by your 
    object rotation to, so you might to customize x, y, or z rotation by yourself.
 */

public class EnemyMovement : MonoBehaviour
{
    public enum Enemy{PLANE, DRAGON}
    public Enemy enemy = Enemy.PLANE;

    // variable for speed and temp speed
    public float enemySpeed;
    private float speed;

    private void Start() {
        speed = enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != Enemy.DRAGON)
        {
            gameObject.transform.Translate(-speed*Time.deltaTime, 0f, 0f);
        }
        else
        {
            gameObject.transform.Translate(0f, 0f, speed*Time.deltaTime);
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
