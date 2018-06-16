using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLevitation : MonoBehaviour {
    public GameObject child;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    // Use this for initialization
    void Start () {
        posOffset = child.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if(child == null)
        {
            Destroy(this.gameObject);
           
        }
        else
        {
            // Float up/down with a Sin()
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            //child.transform.position = tempPos;
            child.transform.localPosition = tempPos;
        }

    }
}
