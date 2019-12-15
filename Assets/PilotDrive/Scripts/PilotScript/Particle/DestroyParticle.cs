using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to destroy spawned particle while the particle is not playing
    you might want to add the script in spawned particle like destroy particle.
 */

public class DestroyParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!particleSystem.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
