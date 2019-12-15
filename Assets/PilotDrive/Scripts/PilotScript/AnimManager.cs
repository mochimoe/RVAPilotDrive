using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    Animator anim;
    int destroyHash = Animator.StringToHash("Destroy");
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DestroyAnim()
    {
        anim.SetTrigger(destroyHash);
        //  if(this.tag == "Blue"){
        //         this.anim.Play("Virus1Destroy");
        //     }else if(this.tag == "Green"){
        //         this.anim.Play("Virus2Destroy");
        //     }else if(this.tag == "Red"){
        //         this.anim.Play("Virus3Destroy");
        //     }else if(this.tag == "Yellow"){
        //         this.anim.Play("Virus4Destroy");
        //     }
    }
}
