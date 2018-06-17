using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    Animator anim;
    bool kyuDead;

	// Use this for initialization
	void Start () {
        kyuDead = KyuHealth.isDead;
        Debug.Log(kyuDead);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (KyuHealth.isDead)
        {
            anim.SetBool("isDead", true);
        }
		
	}
}
