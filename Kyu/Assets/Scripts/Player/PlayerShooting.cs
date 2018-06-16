using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

	public GameObject FireSpawner;
	public GameObject FireBall;
	public float FireBall_Forward_Force;

    float timer;
    //Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    //LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        //gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        /*if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }*/
    }


    /*public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }*/


    void Shoot ()
	{
		timer = 0f;

		//gunAudio.Play ();

		//gunLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();

	}
}
