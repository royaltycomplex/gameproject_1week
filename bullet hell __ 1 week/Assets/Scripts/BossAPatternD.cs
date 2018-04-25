using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAPatternD : MonoBehaviour 
{

	public GameObject bullet;

	public float bulletRotate;
	public float bulletSpeed;

	public bool rotateNegative;

	private int waitToSpawn;
	private int spawnFrame;
	private int cooldown;
	private int maxBullets;
	private int spawnCount;
	private int maxSpawn;

	private float rotate;

	private GameObject enemyBulletSpawn;

	// Use this for initialization
	void Start () 
	{
		enemyBulletSpawn = GameObject.FindWithTag("EnemyBulletSpawn");

		waitToSpawn = 0;
		cooldown = 0;
		spawnCount = 0;
		spawnFrame = 10;
		maxSpawn = 40;
		maxBullets = 5;

		rotate = 360.0f / maxBullets;
		if (rotateNegative) {rotate *= -1;}
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (waitToSpawn >= spawnFrame)
		{

			int i = 0;
			while (i < maxBullets)
			{
				bullet.GetComponent<Mover>().rotate = bulletRotate;
				bullet.GetComponent<Mover>().speed = bulletSpeed;
				Instantiate(bullet, transform.position, transform.rotation, enemyBulletSpawn.transform);
				transform.Rotate(0.0f, rotate, 0.0f);
				i++;
			}
			i = 0;
			waitToSpawn = 0;
			spawnCount++;
		}

		if (spawnCount >= maxSpawn)
		{
			cooldown = 60;
			spawnCount = 0;
		}

		if (cooldown != 0) {cooldown--;}

		if (cooldown == 0) {waitToSpawn++;}

		transform.Rotate(0.0f, rotateNegative == false ? 1.0f : -1.0f, 0.0f);

	}
}
