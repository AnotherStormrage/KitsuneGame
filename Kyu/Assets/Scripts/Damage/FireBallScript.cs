using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.name == "Ghost")
        {
            //Destroy(other.transform.parent.gameObject);
            print("Matamos al enemigo");
            //GameObject aux = other.gameObject;
           other.gameObject.transform.parent.gameObject.GetComponent<GhostScript>().EnemyKilled();
        }
        if (other.gameObject.name == "OniMask")
        {
            //Destroy(other.transform.parent.gameObject);
            print("Matamos al enemigo");
            //GameObject aux = other.gameObject;
            other.gameObject.transform.parent.gameObject.GetComponent<GhostScript>().EnemyKilled();
        }
    }
}
