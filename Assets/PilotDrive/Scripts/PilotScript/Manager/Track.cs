using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Track : MonoBehaviour
{
    public Transform uiCanvas;

    private ARManager arManager;    
    private EnemyManager enemyManager;
    private PowerManager powerManager;
    private EnvirontmentManager environtmentManager;
    private TimeManager timeManager;
    private CloudLocation cloudLocation;
    private UIManager uiManager;
    DefaultTrackableEventHandler myTracker;
    
    private AudioSource voiceAudio;
    public AudioClip foundMarkerVoice;
    public AudioClip loseMarkerVoice;
    public AudioClip startGameVoice;
    
    private bool findMarkerVoiceStatus = true;
    private bool loseMarkerVoiceStatus;

    // Start is called before the first frame update
    void Start()
    {
        voiceAudio = GetComponent<AudioSource>();

        arManager = GameObject.FindObjectOfType<ARManager>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        powerManager = GameObject.FindObjectOfType<PowerManager>();
        environtmentManager = GameObject.FindObjectOfType<EnvirontmentManager>();
        cloudLocation = GameObject.FindObjectOfType<CloudLocation>();
        myTracker = GameObject.FindObjectOfType<DefaultTrackableEventHandler>();

        voiceAudio.PlayOneShot(startGameVoice, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(myTracker.targetStatus == true){
            if(findMarkerVoiceStatus)
            {
                voiceAudio.Stop();
                voiceAudio.PlayOneShot(foundMarkerVoice, 1f);

                findMarkerVoiceStatus = false;
                loseMarkerVoiceStatus = true;
                timeManager.startTime = true;
                enemyManager.startSpawning = true;
                powerManager.canSpawn = true;
                environtmentManager.startSpawning = true;
                cloudLocation.canMove = true;

                arManager.resumeGame();
            }
        }else{
            if(loseMarkerVoiceStatus)
            {
                voiceAudio.Stop();
                voiceAudio.PlayOneShot(loseMarkerVoice, 1f);

                loseMarkerVoiceStatus = false;
                findMarkerVoiceStatus = true;
            }
            enemyManager.startSpawning = false;
            powerManager.canSpawn = false;
            environtmentManager.startSpawning = false;
            cloudLocation.canMove = false;
            timeManager.startTime = false;

            arManager.pauseGame();
        }
    }
}
