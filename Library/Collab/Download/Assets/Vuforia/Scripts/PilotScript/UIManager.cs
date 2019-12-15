using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private ARManager arManager;
    private ScoreManager scoreManager;
    private HealthBar healthBar;
    private PlaneHealth planeHealth;
    private TimeManager timeManager;
    public Text healthUI;
    public Text timeUI;
    public Text scoreUI;
    public GameObject gameOverlayout;
    public GameObject pauseLayout;

    // Start is called before the first frame update
    void Start()
    {
        arManager = GameObject.FindObjectOfType<ARManager>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        planeHealth = GameObject.FindObjectOfType<PlaneHealth>();
        timeManager = GameObject.FindObjectOfType<TimeManager>();
        healthBar = GameObject.FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthUI();
        updateTimeUI();
        updateScoreUI();
        showGameOver();
    }

    private void updateHealthUI()
    {
        healthBar.health = planeHealth.health;
    }

    private void updateTimeUI()
    {
        timeUI.text = "Time : " + (int)timeManager.getCounter();
    }

    private void updateScoreUI()
    {
        scoreUI.text = "Score kamu : " + scoreManager.getFinalScore();
    }

    private void showGameOver()
    {
        if(planeHealth.health != 0)
        {
            gameOverlayout.SetActive(false);
        }
        else
        {
            gameOverlayout.SetActive(true);
            timeManager.pauseTime();
        }
    }

    public void hideGameOver()
    {
        gameOverlayout.SetActive(false);
        arManager.restartGame();
        timeManager.resumeTime();
    }

    public void showPause()
    {
        pauseLayout.SetActive(true);
        
        arManager.pauseGame();
    }

    public void hidePause()
    {
        pauseLayout.SetActive(false);
        
        arManager.resumeGame();
    }
}
