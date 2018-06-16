using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform positionOfCam;
    public Transform orientationOfCam;
    public Transform kyu;
    public float camVelocity = 1f, rotationSpeed = 1f;

    public bool inTransition = false;
    // Use this for initialization
    void Start () {
        transform.position = positionOfCam.transform.position;
        transform.rotation = orientationOfCam.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        if (!inTransition)
        {
            transform.position = Vector3.Lerp(transform.position, positionOfCam.position, camVelocity * Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation(orientationOfCam.transform.rotation);
            //transform.rotation = orientationOfCam.transform.rotation;

            Vector3 relativePos = kyu.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
           // transform.rotation = rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, kyu.position);
    }
}
