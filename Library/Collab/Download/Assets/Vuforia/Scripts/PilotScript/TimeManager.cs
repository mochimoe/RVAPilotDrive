using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float counter;
    public bool startTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(startTime)
        {
            time();
        }
    }

    public void time()
    {
        counter += Time.deltaTime;
    }

    public float getCounter()
    {
        return counter;
    }

    public void pauseTime()
    {
        Time.timeScale = 0;
    }

    public void resumeTime()
    {
        Time.timeScale = 1f;
    }
}
