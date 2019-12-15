using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    this script have function to controllung UI in game
 */

public class UIManager : MonoBehaviour
{
    // other script references
    private ARManager arManager;
    private ScoreManager scoreManager;
    private TimeManager timeManager;
    private CharacterHealth characterHealth;


    // Unity Component
    private AudioSource audioSource;

    // UI component
    public Text timeUI;
    public Text scoreUI;
    public Text scoreGameUI;

    public Image healthBar;
    public Color fullHealth = new Color(0.35f, 1f, 0.35f);
    public Color mediumHealth = new Color(0.9450285f, 1f, 0.4481132f);
    public Color lowHealth = new Color(1f, 0.259434f, 0.259434f);

    // star component
    public int scoreForOneStar;
    public int scoreForTwoStar;
    public int scoreForThreeStar;
    public GameObject[] starImages;
    public AudioClip noStarVoice;
    public AudioClip oneStarVoice;
    public AudioClip twoStarVoice;
    public AudioClip threeStarVoice;
    private bool canPlaySound = true;

    // UI Layout
    public GameObject gameOverlayout;
    public Animator gameOverLayoutAnim;
    public GameObject pauseLayout;
    public Animator pauseLayoutAnim;
    public GameObject tutorialLayout;
    public Animator tutorialLayoutAnim;
    public bool showLayout;
    public bool showGameOverLayout;

    // Start is called before the first frame update
    void Start()
    {
        arManager = GameObject.FindObjectOfType<ARManager>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        timeManager = GameObject.FindObjectOfType<TimeManager>();
        characterHealth = GameObject.FindObjectOfType<CharacterHealth>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimeUI();
        updateScoreGameUI();
        updateFinalScoreUI();
        updateStars();
        updateHealthBar((float)characterHealth.getPlayerHealth());

        showGameOver();
    }

    // this update section have function to update UI in Canvas
    private void updateTimeUI()
    {
        timeUI.text = "Time : " + (int)timeManager.getCounter();
    }

    private void updateFinalScoreUI()
    {
        scoreUI.text = "Score kamu : " + scoreManager.getFinalScore();
    }

    public void updateScoreGameUI()
    {
        scoreGameUI.text = "Score : " + scoreManager.getPlayerScore();
    }

    public void updateHealthBar(float health)
    {
        if(health == 1f)
        {
            healthBar.color = fullHealth;
        }
        else if(health <= 0.75f && health >= 0.5f)
        {
            healthBar.color = mediumHealth;
        }
        else if(health < 0.5f && health > 0.15f)
        {
            healthBar.color = lowHealth;
        }
        else if(health <= 0.15f && health > 0)
        {
            healthBar.color = Color.Lerp(lowHealth, Color.white, Mathf.PingPong(Time.time, 0.3f));
        }

        healthBar.fillAmount = health;
    }

    public void updateStars()
    {
        if(showGameOverLayout && canPlaySound)
        {
            if (scoreManager.getFinalScore() >= scoreForOneStar && scoreManager.getFinalScore() < scoreForTwoStar)
            {
                starImages[0].SetActive(true);

                audioSource.PlayOneShot(oneStarVoice, 1f);
            }
            else if (scoreManager.getFinalScore() >= scoreForTwoStar && scoreManager.getFinalScore() < scoreForThreeStar)
            {
                starImages[0].SetActive(true);
                starImages[1].SetActive(true);

                audioSource.PlayOneShot(twoStarVoice, 1f);
            }
            else if(scoreManager.getFinalScore() >= scoreForThreeStar)
            {
                starImages[0].SetActive(true);
                starImages[1].SetActive(true);
                starImages[2].SetActive(true);

                audioSource.PlayOneShot(threeStarVoice, 1f);
            }
            else
            {
                audioSource.PlayOneShot(noStarVoice, 1f);
            }

            canPlaySound = false;
        }
    }

    // this section have function to show and hide layout in canvas
    private void showGameOver()
    {
        if(characterHealth.getPlayerHealth() > 0)
        {
            gameOverlayout.SetActive(false);
            showGameOverLayout = false;
        }
        else
        {
            gameOverlayout.SetActive(true);
            gameOverLayoutAnim.SetBool("startGameOver", true);
            timeManager.pauseTime();

            showGameOverLayout = true;
        }
    }

    public void hideGameOver()
    {
        gameOverlayout.SetActive(false);
        arManager.restartGame();
        timeManager.resumeTime();

        showGameOverLayout = false;
    }

    public void showPause()
    {
        pauseLayout.SetActive(true);
        
        pauseLayoutAnim.SetBool("pauseOn", true);

        arManager.pauseGame();
    }

    public void hidePause()
    {
        pauseLayoutAnim.SetBool("pauseOn", false);
        StartCoroutine(pauseHideDelay());
        
    }

    public void showTutorial()
    {
        tutorialLayout.SetActive(true);
    }

    public IEnumerator pauseHideDelay()
    {
        yield return new WaitForSeconds(1);

        pauseLayout.SetActive(false);
        
        arManager.resumeGame();
    }

    public void quitGame()
    {
        pauseLayoutAnim.SetBool("pauseOn", false);
        StartCoroutine(pauseHideDelay());
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        
    }
}
