using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterEnemies : MonoBehaviour {

    Text enemyText;
    public static int counterEnemy;

	// Use this for initialization
	void Start () {

        counterEnemy = 0;
        enemyText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        enemyText.text = counterEnemy + " Onis alive";		
	}
}
