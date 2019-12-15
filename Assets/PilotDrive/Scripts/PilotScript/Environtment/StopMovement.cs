using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this sript have function to give restriction to player movement and cloud movement, you can add this script
    to gameObject with triggered collider
 */

public class StopMovement : MonoBehaviour
{
    // this script is use for stop player movement if player hit restriction area
    public enum Movement{RIGHT, LEFT}
    public Movement movement = Movement.RIGHT;

    private void OnTriggerEnter(Collider plane) {

        if(plane.gameObject.CompareTag("Player") || plane.gameObject.CompareTag("Invulnerable"))
        {
            if(movement == Movement.RIGHT)
            {
                plane.GetComponent<PlayerMovement>().controllRight = false;
                plane.GetComponent<PlayerMovement>().moveRight = false;
                plane.GetComponent<PlayerMovement>().controllLeft = true;
            }
            else 
            {
                plane.GetComponent<PlayerMovement>().controllLeft = false;
                plane.GetComponent<PlayerMovement>().moveLeft = false;
                plane.GetComponent<PlayerMovement>().controllRight = true;
            }
        }
    }
}
