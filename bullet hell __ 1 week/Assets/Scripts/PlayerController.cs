using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private float nextFire;
	private GameObject bulletObject;
	private bool focus;
	private float defSpeed;

	public float speed;
	public float tilt;
	public Boundary boundary;
	public float fireRate;

	public GameObject bullet;
	public Transform[] bulletSpawns;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		bulletObject = GameObject.FindWithTag("PlayerBulletSpawn");
		focus = GetComponent<LightSwitch>().focus;
		defSpeed = speed;
	}

	void Update()
	{
		focus = GetComponent<LightSwitch>().focus;
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			foreach (Transform bulletSpawn in bulletSpawns)
			{
				Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation, bulletObject.transform);
			}
		}
		if (focus)
		{
			speed = defSpeed / 3;
		}
		else if (!focus)
		{
			speed = defSpeed;
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
