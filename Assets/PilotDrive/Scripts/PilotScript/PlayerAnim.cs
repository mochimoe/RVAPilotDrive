using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rightButtonDown()
    {
        anim.SetBool("TurnRight", true);
        anim.SetBool("TurnLeft", false);
    }
    
    public void rightButtonUp()
    {
        anim.SetBool("TurnRight", false);
        anim.SetBool("TurnLeft", false);
    }
    
    public void leftButtonDown()
    {
        anim.SetBool("TurnRight", false);
        anim.SetBool("TurnLeft", true);
    }
    
    public void leftButtonUp()
    {
        anim.SetBool("TurnRight", false);
        anim.SetBool("TurnLeft", false);
    }
}
