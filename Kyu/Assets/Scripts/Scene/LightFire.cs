using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightFire : MonoBehaviour {

    private float random;
    private Light _light;

	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
        StartCoroutine(Parpadeo());
}
	
	// Update is called once per frame
	IEnumerator Parpadeo () {
        while (true)
        {
            random = Random.Range(0, 100);
            if (random < 40)
            {
                _light.intensity = 5;
                yield return new WaitForSeconds(0.8f);
            }
            else
            {
                _light.intensity = 3;
                yield return new WaitForSeconds(0.05f);
            }
            
        }
	}
}
