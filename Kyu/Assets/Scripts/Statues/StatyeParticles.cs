using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatyeParticles : MonoBehaviour {

    private GameObject Kyu;
    private bool particlesRunning = false;
    //public ParticleEmitter pm;
    public ParticleSystem ps;
    private bool playerIsNear = false;
    //ParticleSystemEmission emission;
     
    // Use this for initialization
    private void Awake()
    {
 
        var emission = ps.emission;
    }
    void Start () {
        ps.Stop();
        //ps.emission.enabled = true;
        var emission = ps.emission;
        emission.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerIsNear)
        {
            if (particlesRunning)
            {

            }
            else
            {
                particlesRunning = true;
                //enable particles
                //pm.enabled = true;
                //ps.enableEmission = true;
                ps.Play();
            }
        }
        else
        {
            if (particlesRunning)
            {
                particlesRunning = false;
                //stop particles
                //pm.enabled = false;
                ps.Stop();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsNear = false;
        }
    }
}
