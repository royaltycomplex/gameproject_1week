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
	private float waitToRespawn;
	private float respawnFrame;

	public float speed;
	public float tilt;
	public Boundary boundary;
	public float fireRate;
	public int lives;
	public bool respawning = false;

	public GameObject bullet;
	public Transform[] bulletSpawns;

//	private GameObject gc;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		bulletObject = GameObject.FindWithTag("PlayerBulletSpawn");
		focus = GetComponent<LightSwitch>().focus;
		defSpeed = speed;
		waitToRespawn = 0;
		respawnFrame = 180;

//		gc = GameObject.FindWithTag("GameController");
	}

	void Update()
	{
//		if (gc.GetComponent<GameController>().continues == 0) {respawning = false;}

		focus = GetComponent<LightSwitch>().focus;

		lives = Mathf.Clamp(lives, 0, 99);

		if (!respawning)
		{
			GetComponent<CapsuleCollider>().enabled = true;
			GetComponentInChildren<MeshRenderer>().enabled = true;
		}

		else if (respawning)
		{
			GetComponent<CapsuleCollider>().enabled = false;
			if (waitToRespawn >= respawnFrame)
			{
				waitToRespawn = 0;
				respawning = false;
			}
			if (waitToRespawn % 12 == 0)
			{
				GetComponentInChildren<MeshRenderer>().enabled = false;
			}
			else if (waitToRespawn % 12 == 6)
			{
				GetComponentInChildren<MeshRenderer>().enabled = true;
			}
			waitToRespawn++;
		}



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
