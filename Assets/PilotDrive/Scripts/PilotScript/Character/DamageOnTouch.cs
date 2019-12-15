using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to give damage in object with tag you disire, 
    but remember the target must have health.
 */

public class DamageOnTouch : MonoBehaviour
{
    // other script references
    private CharacterController characterController;

    public string tagName;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider target) {
        if(target.gameObject.CompareTag(tagName))
        {
            target.GetComponent<CharacterHealth>().reduceHealth(characterController.enemyDamage);
        }
    }
}   
