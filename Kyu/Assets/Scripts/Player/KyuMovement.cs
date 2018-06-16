using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyuMovement : MonoBehaviour {

    public float speed = 0f;
    public float SlerpSpeed = 5f;
	public float TurnSpeed = 180f;

    Vector3 movement;
    Vector3 rotation;

    Animator anim;
    Rigidbody playerRigidbody;

    int floorMask;
    float camRayLenght = 100f;


	public float TurnInputValue = 0f;
	public float MovementInputValue = 0f;

    public float camVelocity = 1f;
    public Transform animationCamera, animationCamera2;
    public float animationCameraVelocity,animationCameraRotation;
    public bool nearStatue = false;
    public Vector3 cameraDistanceInitial;
    public Quaternion initialKyuRotation, initialCamRotation;

    Collider lastStatue;

    //public Camera cam;
    public Camera cam;

    public static bool intoStatue = false;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        //cam = GetComponentInChildren<Camera>();
        cameraDistanceInitial = transform.position - cam.transform.position;
        //print(cameraDistanceInitial);
        initialKyuRotation = transform.rotation;
        initialCamRotation = cam.transform.rotation;

    }

    private void FixedUpdate()
    {
		TurnInputValue = Input.GetAxis ("Horizontal");
		MovementInputValue = Input.GetAxis ("Vertical");

		float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }



    private void Update()
    {

        if (Input.GetKeyDown("space") && nearStatue)
        {
            StartCoroutine(ChangeCameraToStatue(lastStatue));
        }
    }



    private void Move(float h, float v)
    {

		bool moving = h != 0f || v != 0f;
		bool run = speed > 10f;

		if (moving && run == false) 
			speed += 0.1f;
		else if (moving && run) 
			speed = 10f;
		else
			speed = 0f;

		movement = transform.forward * MovementInputValue * speed * Time.deltaTime;

		playerRigidbody.MovePosition (playerRigidbody.position + movement);
    }

    void Turning()
    {        
		float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		playerRigidbody.MoveRotation (playerRigidbody.rotation * turnRotation);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);

		bool running = speed > 6f;
		anim.SetBool("IsRunning", running);
    }


    IEnumerator ChangeCameraToStatue(Collider other)
    {

        Debug.Log("Cabmiamos camara");
        intoStatue = true;          //This to make the enemies continue to the core.

        Transform point1;
        Transform point2;
        Component[] components = other.gameObject.GetComponentsInChildren<Transform>();
       /* print(components.Length);
        print(components[0]);
        print(components[1]);
        print(components[2]);
        print(components[3]);
        print(components[4]);
        print(components[5]);*/



        point1 = components[1].transform;
        point2 = components[2].transform;
        print(point1);
        print(point2);
        cam.GetComponent<CameraScript>().inTransition = true;

        while (Vector3.Distance(cam.transform.position, point1.position) >= 0.8f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, point1.position, animationCameraVelocity * Time.deltaTime);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, point1.rotation, animationCameraRotation * Time.deltaTime);
            print("moviendo");
            yield return null;


        }
        while (Vector3.Distance(cam.transform.position, point2.position) >= 0.5f)
        {
            //print(Vector3.Distance(cam.transform.position, animationCamera2.position));
            cam.transform.position = Vector3.Lerp(cam.transform.position, point2.position, animationCameraVelocity * Time.deltaTime);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, point2.rotation, animationCameraRotation * Time.deltaTime);
            yield return null;

        }
        cam.enabled = false;
        other.gameObject.SetActiveRecursively(true);
        other.gameObject.GetComponentInChildren<Camera>().enabled = true;
        other.gameObject.GetComponent<StatueMovement>().cam.GetComponent<AudioListener>().enabled = true;
        other.gameObject.GetComponent<StatueMovement>().enabled = true;
        this.gameObject.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Statue")
        {
            print("cerca estatua");
            nearStatue = true;
            lastStatue = other;
            //StartCoroutine(ChangeCameraToStatue(other));
            //other.gameObject.GetComponent<Camera>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Statue")
        {
            nearStatue = false;
            lastStatue = null;
            print("lejos estatua");
        }
    }



}