using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManager : MonoBehaviour
{
    private TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }
    
    public void restartGame()
    {
        Application.LoadLevel(0);
    }

    public void pauseGame()
    {
        timeManager.pauseTime();
    }

    public void resumeGame()
    {
        timeManager.resumeTime();
    }
}
