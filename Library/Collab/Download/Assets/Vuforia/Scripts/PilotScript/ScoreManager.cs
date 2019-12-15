using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TimeManager timeManager;
    public int score;
    private int playerScore;
    

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getPlayerScore()
    {
        return this.playerScore;
    }

    public void updateScore(int score)
    {
        this.playerScore += score;
    }

    public int getFinalScore()
    {
        return playerScore + (int)timeManager.getCounter();
    }
}
