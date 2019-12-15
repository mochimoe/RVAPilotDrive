using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCloud : MonoBehaviour
{
    private void OnTriggerEnter(Collider plane) {
        if(plane.gameObject.tag == "DestroyField")
        {
            Debug.Log("oke");
            gameObject.SetActive(false);
        }
    }
}
