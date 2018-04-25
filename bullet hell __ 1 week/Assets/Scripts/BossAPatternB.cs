using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAPatternB : MonoBehaviour 
{

	public GameObject[] bullets;

	private GameObject enemyBullets;

	private int waitToSpawn;
	private int spawnFrame;
	private int waitToShoot;
	private int shootFrame;
	private int maxBullets;
	private int bulletCount;
	private int index;

	private GameObject[] bulletsSpawned;
	private int newIndex;


	// Use this for initialization
	void Start ()
	{
		waitToShoot = 0;
		waitToSpawn = 0;
		bulletCount = 0;
		index = 0;
		newIndex = 0;
		spawnFrame = 2;
		shootFrame = 30;
		maxBullets = 36;
		bulletsSpawned = new GameObject[maxBullets];

		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((waitToSpawn >= spawnFrame))
		{
			if (bulletCount % 2 == 0) {index = 0;} else {index = 1;}
			bullets[index].GetComponent<Mover>().speed = 0;
			bullets[index].GetComponent<Mover>().rotate = 0;
			if (bulletCount > 0) {transform.Rotate(0.0f, -10.0f, 0.0f);}
			bulletsSpawned[newIndex] = Instantiate(bullets[index], transform.position - (transform.forward * 1.0f), transform.rotation, enemyBullets.transform);

			bulletCount++;
			newIndex++;
			waitToSpawn = 0;
		}
		if (bulletCount >= maxBullets)
		{
			waitToShoot++;
		}
		if (bulletCount < maxBullets) {waitToSpawn++;}

		if (waitToShoot >= shootFrame)
		{
			foreach (GameObject bullet in bulletsSpawned)
			{
				bullet.GetComponent<Mover>().speed = 9.0f;
			}
			Destroy(gameObject);
		}
	}
}
