using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is used to give score in player
 */

public class ScoreManager : MonoBehaviour
{
    // other script references
    private TimeManager timeManager;

    private int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }

    public int getPlayerScore()
    {
        return this.playerScore;
    }

    public void updateScore(int score)
    {
        this.playerScore += score;
    }

    // this method is used to get final score (player score + play time)
    public int getFinalScore()
    {
        return playerScore + (int)timeManager.getCounter();
    }
}
