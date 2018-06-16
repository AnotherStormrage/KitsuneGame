using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public int setNumberOfRounds = 0;
    public static int numberOfRounds;
    public int setR1, setR2, setR3, setR4, setR5 = 0;
    public static int r1, r2, r3, r4, r5; //the number of enemies for each round

    public static int currentNumberOfEnemies;

    private void Awake()
    {
        numberOfRounds = setNumberOfRounds;
        r1 = setR1;
        r2 = setR2;
        r3 = setR3;
        r4 = setR4;
        r5 = setR5;
        currentNumberOfEnemies = 0;
    }
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
