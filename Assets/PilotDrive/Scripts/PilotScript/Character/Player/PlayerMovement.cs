using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to give movement in player, the movement just horizontal. 
    this script is used in UI button
 */

public class PlayerMovement : MonoBehaviour
{
    // this variable controll player speed
    public float speed;

    // this variable is condition, and direction player movement
    public bool controllLeft = true, controllRight = true;
    public bool moveLeft = false, moveRight = false;
    public GameObject player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveLeft)
        {
            gameObject.transform.Translate(-speed*Time.deltaTime, 0f, 0f);
            controllRight = true;
        }

        if(moveRight)
        {
            gameObject.transform.Translate(speed*Time.deltaTime, 0f, 0f);
            controllLeft = true;
        }
    }

    public void onPointerDownRight()
    {
        if(controllRight)
        {
            moveRight = true;
            player.GetComponent<PlayerAnim>().rightButtonDown();
        }
    }

    public void onPointerUpRight()
    {
        moveRight = false;
        player.GetComponent<PlayerAnim>().rightButtonUp();
        stopMove();
    }

    public void onPointerDownLeft()
    {
        if(controllLeft)
        {
            moveLeft = true;
            player.GetComponent<PlayerAnim>().leftButtonDown();
        }
    }

    public void onPointerUpLeft()
    {
        moveLeft = false;
        stopMove();
        player.GetComponent<PlayerAnim>().leftButtonUp();
    }

    public void stopMove()
    {
        gameObject.transform.Translate(0f, 0f, 0f);
    }
}
