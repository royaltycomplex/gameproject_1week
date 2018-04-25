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

	private GameObject enemyBullets;

	private GameObject bulletSpawn;

	// Use this for initialization
	void Start () 
	{
		phaseCount = GetComponent<BossHP>().phaseCount;

		waitToMove = 0;
		waitFrame = 300;
		waitToSpawn = 0;
		spawnFrame = 12;

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

			if (movedToSide && transform.position == new Vector3(-xSide, 5.0f, zTransRand)) {Instantiate(bulletPatterns[1], transform.position, transform.rotation); moveToCenter = true;}

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



	}
}
