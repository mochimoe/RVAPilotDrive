using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script give movement to cloud, but remember the direction of movement is decided by your 
    object rotation to, so you might to customize x, y, or z rotation by yourself
 */

public class CloudMovement : MonoBehaviour
{
    // this variable is used for speed of cloud movement
    public float cloudSpeedMin;
    public float cloudSpeedMax;
    private float finalSpeed;
    private float tempSpeed;

    // Start is called before the first frame update
    void Start()
    {
        finalSpeed = Random.Range(cloudSpeedMin, cloudSpeedMax);
        tempSpeed = finalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0f, finalSpeed*Time.deltaTime, 0f);
    }

    public void setSpeed(float speed)
    {
        this.finalSpeed = speed;
    }

    public float getTempSpeed()
    {
        return this.tempSpeed;
    }
}
