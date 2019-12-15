using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to move the cloudpoint location, but remember this need an restriction area
    (Batas kanan, Batas kiri) to move bounce, you can find the restriction area in hirarchy.
 */

public class CloudLocation : MonoBehaviour
{
    // this variable is use for controlling cloud spawn location movement
    private int destination;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        destination = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            float randomY = Random.Range(-1.5f, 1.5f);

            gameObject.transform.Translate(0f, randomY*Time.deltaTime,0f);

            if(destination != 0)
            {
                gameObject.transform.Translate(-3f*Time.deltaTime, 0, 0);
            }
            else
            {
                gameObject.transform.Translate(3f*Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "BatasKiri")
        {
            destination = 0;
        }

        if(other.gameObject.tag == "BatasKanan")
        {
            destination = 1;
        }
    }
}
