using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float cloudSpeedMin;
    public float cloudSpeedMax;
    private float finalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        finalSpeed = Random.Range(cloudSpeedMin, cloudSpeedMax);
    }

    // Update is called once per frame
    void Update()
    {


        gameObject.transform.Translate(0f, 0f, -finalSpeed*Time.deltaTime);
    }
}
