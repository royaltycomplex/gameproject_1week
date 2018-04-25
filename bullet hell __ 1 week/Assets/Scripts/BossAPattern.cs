using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAPattern : MonoBehaviour 
{

	public GameObject[] bulletPatterns;


	public float speed;

	private int phaseCount;

	private bool zTransPicked;
	private bool sidePicked;
	private bool movedToSide = false;
	private bool moveToCenter = false;
	private bool wait = true;
	private int zTransRand;
	private int xSide;

	private int waitToMove;
	private int waitFrame;

	private int waitToSpawn;
	private int spawnFrame;

	private bool phase2Spawned = false;
	private bool moved = false;

	public GameObject enemyBullets;

	private GameObject bulletSpawn;

	// Use this for initialization
	void Start () 
	{
		phaseCount = GetComponent<BossHP>().phaseCount;

		waitToMove = 0;
		waitFrame = 300;
		waitToSpawn = 0;
		spawnFrame = 13;

		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
	}
	
	// Update is called once per frame
	void Update () 
	{
		phaseCount = GetComponent<BossHP>().phaseCount;

		if (phaseCount == 0 && !wait)
		{
			if (!zTransPicked) {zTransRand = Random.Range (25, 15); zTransPicked = true;}
			if (!sidePicked) {xSide = Random.Range (0, 2) == 0 ? -9 : 9; sidePicked = true;}
			if (!movedToSide) {transform.position = Vector3.MoveTowards(transform.position, new Vector3(xSide, 5.0f, zTransRand), speed * Time.deltaTime);}
				
			if (transform.position == new Vector3(xSide, 5.0f, zTransRand))
			{
				movedToSide = true;
				Instantiate(bulletPatterns[1], transform.position, transform.rotation);
			}

			if (movedToSide && !moveToCenter) 
			{
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(-xSide, 5.0f, zTransRand), speed * Time.deltaTime);

				if (waitToSpawn >= spawnFrame) {Instantiate(bulletPatterns[1], transform.position, transform.rotation); waitToSpawn = 0;}
				waitToSpawn++;
				
			}

			if (movedToSide && transform.position == new Vector3(-xSide, 5.0f, zTransRand)) {moveToCenter = true;}

			if (movedToSide && moveToCenter) {transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, 5.0f, 24.0f), speed * Time.deltaTime);}

			if (movedToSide && moveToCenter && transform.position == new Vector3(0.0f, 5.0f, 24.0f))
			{
				zTransPicked = false; sidePicked = false; movedToSide = false; moveToCenter = false; wait = true; waitToMove = 0; waitToSpawn = 0;
			}
		}

		if (phaseCount == 0 && wait)
		{
			if (waitToMove == 0) {bulletSpawn = Instantiate(bulletPatterns[0], transform.position, transform.rotation, gameObject.transform);}
			if (waitToMove >= waitFrame) {Destroy(bulletSpawn); wait = false;}
			waitToMove++;
		}

		if (phaseCount == 1)
		{
			zTransPicked = false; sidePicked = false; movedToSide = false; moveToCenter = false; wait = false;
			if (!phase2Spawned) {transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, 5.0f, 20.0f), speed * Time.deltaTime);}
			if (!phase2Spawned && transform.position == new Vector3(0.0f, 5.0f, 20.0f))
			{
				if (bulletSpawn != null) {Destroy(bulletSpawn);}
//				Instantiate(bulletPatterns[0], transform.position, transform.rotation, gameObject.transform);
				Instantiate(bulletPatterns[3], transform.position + (transform.right * 5.0f), transform.rotation, enemyBullets.transform);
				Instantiate(bulletPatterns[4], transform.position - (transform.right * 5.0f), transform.rotation, enemyBullets.transform);
				Instantiate(bulletPatterns[2], transform.position, transform.rotation, gameObject.transform);
				speed = 1.5f;
				phase2Spawned = true;
			}
			if (phase2Spawned)
			{

				if (!moved) {xSide = Random.Range(-8, 8); zTransRand = Random.Range(10, 24); moved = true;}
				if (moved) {transform.position = Vector3.MoveTowards(transform.position, new Vector3(xSide, 5.0f, zTransRand), speed * Time.deltaTime);}
				if (moved && transform.position == new Vector3(xSide, 5.0f, zTransRand)) {moved = false;}

			}
		}

	}
}
