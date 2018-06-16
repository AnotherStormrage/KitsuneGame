using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyuAttack : MonoBehaviour {

	public float timeBetweenBullets = 0;

	public GameObject FireSpawner;
	public GameObject FireBall;
	public float FireBall_Forward_Force;

	float timer;
	//ParticleSystem smokeParticles;

	void Awake(){
		//smokeParticles = GetComponent<ParticleSystem> ();
	}

	void Update ()
	{
		timer += Time.deltaTime;

		if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets) {
			Shoot ();
		}
	}
		
	void Shoot ()
	{
		timer = 0f;

		/*smokeParticles.Stop ();
		smokeParticles.Play ();*/

		GameObject Temporary_FireBall_Handler;
		Temporary_FireBall_Handler = Instantiate (FireBall, FireSpawner.transform.position, FireSpawner.transform.rotation) as GameObject;
		Temporary_FireBall_Handler.transform.Rotate (Vector3.left * 90);

		Rigidbody Temporary_RigidBody;
		Temporary_RigidBody = Temporary_FireBall_Handler.GetComponent<Rigidbody> ();
		Temporary_RigidBody.AddForce (transform.forward * FireBall_Forward_Force);

		Destroy (Temporary_FireBall_Handler, 2f);

	}
}
