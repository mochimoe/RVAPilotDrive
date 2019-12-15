using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is used to destroy spawned enemy, and in this script player score is added.
 */

public class DestroyEnemy : MonoBehaviour
{
    // other script references
    private CharacterController characterController;
    private ScoreManager scoreManager;
    
    // this variable is use for spawn particle effect
    public Transform spawnParent;
    
    public GameObject destroyParticle;

    public AudioSource destroySound;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider plane) {
        if(plane.gameObject.tag == "Player")
        {       
            Instantiate(destroyParticle, transform.position, transform.rotation, spawnParent);

            destroySound.Play();

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            if(!destroySound.isPlaying)
            {
                Destroy(gameObject);
            }   
        } 
        else if(plane.gameObject.tag == "DestroyField")
        {
            addScore(characterController.getUpdatedScore());

            Destroy(gameObject);
        }
        else if(plane.gameObject.tag == "Invulnerable")
        {
            Instantiate(destroyParticle, transform.position, transform.rotation, spawnParent);
            
            destroySound.Play();

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            if(!destroySound.isPlaying)
            {
                Destroy(gameObject);
            }   
        }
    }

    // this method have function to add score in score manager
    public void addScore(int score)
    {
        scoreManager.updateScore(score);
    }
}
