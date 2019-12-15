using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLocation : MonoBehaviour
{
    private int destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(destination != 0)
        {
            gameObject.transform.Translate(-3f*Time.deltaTime, 0, 0);
        }
        else
        {
            gameObject.transform.Translate(3f*Time.deltaTime, 0, 0);
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
