using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveF : MonoBehaviour
{

	public GameObject pattern;
	public float speed;
	public float rotate;

	private int waitBeforeShoot;
	private int shootFrame;

	private int shootCount;
	private int shootLimit;

	private int shootNumber;
	private int shootMax;

	private bool onScreen = false;
	private bool moving = true;
	private bool moving2 = false;

	private GameObject bulletSpawn;
	
	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		waitBeforeShoot = 0;
		shootCount = 0;
		shootNumber = 0;
		shootFrame = 25;
		shootLimit = 90;
		shootMax = 2;
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
			bulletSpawn = Instantiate(pattern, transform.position - (transform.forward * 1.0f), transform.rotation, gameObject.transform);
			onScreen = false;
			moving = false;
		}
		if ((waitBeforeShoot >= shootFrame && shootNumber < shootMax) && !onScreen)
		{
			shootCount++;
		}
		if (shootCount >= shootLimit)
		{
//			if (shootNumber == 0)
//			{
//				shootFrame *= 2;
//			}
			onScreen = true;
			waitBeforeShoot = 0;
			shootCount = 0;
			Destroy(bulletSpawn);
			shootNumber++;
		}
		if (waitBeforeShoot >= shootFrame && shootNumber >= shootMax)
		{
			waitBeforeShoot = 0;
			moving2 = true;
		}
		if (moving2)
		{
			rb.position += -transform.forward * Time.deltaTime * speed;
			rb.rotation *= Quaternion.Euler (0.0f, rotate, 0.0f);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary")
		{
			onScreen = true;
		}
	}
}