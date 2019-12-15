using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have role to cotroll the game like pause, restart, and resume.
 */

public class ARManager : MonoBehaviour
{
    // other script references
    private TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }
    
    public void restartGame()
    {
        Application.LoadLevel(0);
        timeManager.resumeTime();
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
