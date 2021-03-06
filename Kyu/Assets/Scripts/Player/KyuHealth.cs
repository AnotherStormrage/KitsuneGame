using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KyuHealth : MonoBehaviour {

	public Image damageImage;
    public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f,0f,0.1f);
  	public Slider healthSlider;
	public int startingHealth;
	public int currentHealth;

	Transform player;
	Animator anim;
	KyuMovement kyuMovement;
	public static bool isDead;
	public bool damaged = false;


	void Awake()
	{
		anim = GetComponent<Animator> ();
		kyuMovement = GetComponent<KyuMovement> ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		currentHealth = startingHealth;
	}
		
	// Use this for initialization
	void Start () 
	{
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        healthSlider.value = currentHealth;
    }


	public void TakeDamage (int amount)
    {
        damaged = true;
		currentHealth -= amount;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) 
		{
			Death ();
		}
    }

	void Death()
	{
		isDead = true;

		//anim.SetTrigger ("Die");

		//playerAudio.clip = deathClip;
		//playerAudio.Play();

		kyuMovement.enabled = false;
	}

    //IEnumerator DamageFlash()
    //{
        //yield return null;
    //}
}
