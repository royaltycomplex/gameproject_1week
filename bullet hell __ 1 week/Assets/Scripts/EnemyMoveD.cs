using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveD : MonoBehaviour {

	public GameObject pattern;
	public float speed;
	public float rotateSpeed;

	private Rigidbody rb;
	private GameObject player;

	private int waitBeforeShoot;
	private int shootFrame;
	private int shootNumber;
	private int shootMax;
	private int shootCount;
	private int shootLimit;

	private float rotateDirection;
	private Vector3 targetRotation;

	private bool onScreen = false;
	private bool moving = true;

	private bool rotating = false;
	private bool shooting = false;

	private GameObject bulletSpawn;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();	
		player = GameObject.Find("Player");

		waitBeforeShoot = 0;
		shootFrame = 40;
		shootNumber = 0;
		shootMax = 2;
		shootCount = 0;
		shootLimit = 120;
	}
	
	// Update is called once per frame
	void Update () 
		{
		if (waitBeforeShoot < shootFrame && moving)
		{
			rb.position += -transform.forward * Time.deltaTime * speed;
		}
		if (onScreen)
		{
			waitBeforeShoot++;
		}
		if ((waitBeforeShoot >= shootFrame && shootNumber < shootMax) && onScreen)
		{

			if (!rotating && !shooting)
			{
				if (player != null)
				{
					targetRotation = transform.position - player.transform.position;
//					targetRotation.z = 0.0f;
					targetRotation.y = 0.0f;
				}
//				if (targetRotation > 0) {rotateDirection = 1.0f;}
//				else if (targetRotation < 0) {rotateDirection = -1.0f;}
				rotating = true;
				moving = false;
			}


			if (shooting)
			{
			bulletSpawn = Instantiate(pattern, transform.position, transform.rotation, gameObject.transform);
			onScreen = false;
			moving = false;
			shooting = false;
			}
		}
		if ((waitBeforeShoot >= shootFrame && shootNumber < shootMax) && !onScreen)
		{
			shootCount++;
		}
		if (shootCount >= shootLimit)
		{
			if (shootNumber == 0)
			{
				shootFrame *= 2;
			}
			onScreen = true;
			waitBeforeShoot = 0;
			shootCount = 0;
			Destroy(bulletSpawn);
			shootNumber++;
		}
		if (waitBeforeShoot >= shootFrame && shootNumber >= shootMax)
		{
			waitBeforeShoot = 0;
			moving = true;
		}

		if (rotating)
		{
//			transform.rotation *= Quaternion.Euler (0.0f, rotateDirection * rotateSpeed, 0.0f);
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetRotation, rotateSpeed * Time.deltaTime, 0.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
//			if ((targetRotation > 0 && transform.rotation.y >= (targetRotation / 18)) || (targetRotation < 0 && transform.rotation.y <= (targetRotation / 18))) 
//			if (transform.rotation.y <= -5.0f)
//			if (newDir == transform.forward)
//			{
//				transform.rotation = Quaternion.Euler (0.0f, targetRotation, 0.0f);
//				shooting = true;
//				rotating = false;
//			}

			Vector3 dirFromAtoB = targetRotation.normalized;
			float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);
				
			if (dotProd > 0.99999) 
			{
				rotating = false;
				shooting = true;
			}

//			print(transform.forward);
		}

//			bulletSpawn = Instantiate(pattern, transform.position, transform.rotation, gameObject.transform);
//			onScreen = false;
//			moving = false;
//		print(transform.rotation.y);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary")
		{
			onScreen = true;
		}
	}
}
