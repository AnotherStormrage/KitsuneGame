using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostScript : MonoBehaviour {
    Transform player;
    Transform levelCore;

    public float distToPlayer, distToCore, maxDistToCore;
    public float maxDistToPly = 15f;
    public float disToCollisionWithPlayer;
    NavMeshAgent nav;
    enum state { idle, following, goCore, death };
    public int health = 1;

    public bool isDead;

    state currentState;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        levelCore = GameObject.FindGameObjectWithTag("Core").transform;
        nav = GetComponent<NavMeshAgent>();
        isDead = false;

    }

    // Use this for initialization
    void Start () {
        currentState = state.goCore;
        nav.SetDestination(levelCore.position);
	}
	
	// Update is called once per frame


    void Update()
    {

        distToPlayer = Vector3.Distance(player.position, this.transform.position);
        distToCore = Vector3.Distance(levelCore.position, this.transform.position);
        //print(isDead);
        if (isDead)
        {
            currentState = state.death;
        }
        /* if(distToPlayer<= maxDistToPly)
         {
             currentState = state.following;
             nav.enabled = true;
             nav.SetDestination(player.position);

         }
         else
         {
             nav.enabled = false;
         }
         */

        /*
        if (!(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0))
        {
            currentState = state.death;
        }
        */

        switch (currentState)
        {
            case state.following:
                if (distToPlayer > maxDistToPly)
                {
                    currentState = state.goCore; 
                    nav.SetDestination(levelCore.position);

                }
                else   // here is where the ghost is following the player
                {
                    if(distToPlayer <= disToCollisionWithPlayer)
                    {
                        print("HAS PERDIDO UNA VIDA");
                        player.GetComponent<KyuHealth>().TakeDamage(10);
                        Destroy(this.gameObject);
                    }
                    else //if not collides with the player
                    {
                        if (KyuMovement.intoStatue)
                        {
                            currentState = state.goCore;
                            nav.SetDestination(levelCore.position);
                            print("el jugador entra en la estatua");
                        }
                        else
                        {
                            nav.SetDestination(player.position);
                        }
                    }

                }
                
                break;

            case state.goCore:
                if (distToPlayer <= maxDistToPly && !KyuMovement.intoStatue)
                {
                    currentState = state.following; //core -> following

                    nav.SetDestination(player.position);
                }
                else
                {
                    if (distToCore <= maxDistToCore)
                    {
                        print("HAS PERDIDO UNA VIDA");
                        player.GetComponentInChildren<KyuHealth>().TakeDamage(5);
                        Destroy(this.gameObject);
                    }
                }
                break;

            case state.idle:
               /* if (distToPlayer <= maxDistToPly)
                {
                    currentState = state.following; //idle -> following

                    nav.SetDestination(player.position);

                }*/
                break;

            case state.death:
                print("muerto");
                nav.enabled = false;
                Destroy(this.gameObject);
                //Destroy(this.transform.parent.gameObject);
                break;
        }
    }

    public void EnemyKilled()
    {
        print("cambiamos el state a death");
        isDead = true;
        currentState = state.death;

        //health = 0;
        //print(health);
        //Destroy(this.gameObject);
        //Destroy(this.transform.parent.gameObject);

    }
}
