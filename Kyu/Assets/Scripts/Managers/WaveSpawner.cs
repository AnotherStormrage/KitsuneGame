﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {


    public enum SpawnState { SPAWNING, WAITING, COUNTING};
    


    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenwaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;
    GameObject aux;



    void Start () {
        waveCountdown = timeBetweenwaves;
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points reference.");
        }

        print(GameObject.FindGameObjectsWithTag("Enemy").Length);
       aux = GameObject.FindGameObjectWithTag("Enemy");

       
        //print(aux.transform.parent.gameObject.name);
       // Destroy(aux);
    }
	
	void Update ()
    {
        //print(aux.transform.position);
        if(state == SpawnState.WAITING)
        {
            //print(EnemyIsAlive());
            if (!EnemyIsAlive())
            {
                //begin a new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                //start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));

            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
		
	}

    void WaveCompleted()
    {
        Debug.Log("Wave completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenwaves;

        if(nextWave + 1 > waves.Length - 1)
        {       //HERE IS WHERE THE GAME IS COMPLETED
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE! Looping...");
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            print("Buscamos");
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
            GameObject aux = GameObject.FindGameObjectWithTag("Enemy");
            //print(aux);
            //print(aux.transform.position);
            //print(aux.name);
            print(GameObject.FindGameObjectsWithTag("Enemy").Length);
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        
        for(int i = 0; i< _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy " + _enemy.name);

        Transform _sp =  spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        counterEnemies.counterEnemy++;
    }
}
