using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAPatternA : MonoBehaviour {

	public GameObject bullet;

	private int waitToSpawn;
	private int maxBullets;
	private int spawnFrame;
	private int spawnCount;
	private int spawnMax;
	private int cooldown;

	private GameObject enemyBullets;

	// Use this for initialization
	void Start () {
		waitToSpawn = 0;
		maxBullets = 36;
		spawnFrame = 3;
		spawnCount = 0;
		spawnMax = 2;
		cooldown = 0;

		enemyBullets = GameObject.Find("EnemyBullets");
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown == 0)
		{
			waitToSpawn++;
			if (waitToSpawn >= spawnFrame)
			{
				int i = 0;
				while (i < maxBullets)
				{
					bullet.GetComponent<Mover>().rotate = 8;
					if (spawnCount > 0)
					{
						bullet.GetComponent<Mover>().speed = 7;
					}
					else
					{
						bullet.GetComponent<Mover>().speed = 8;
					}
					Instantiate(bullet, transform.position, transform.rotation, enemyBullets.transform);
					transform.Rotate(0.0f, 10.0f, 0.0f);
					i++;
				}
				i = 0;
				spawnCount++;
				waitToSpawn = 0;
			}
			if (spawnCount == spawnMax)
			{
				cooldown = 35;
				spawnCount = 0;
			}
		}
		else if (cooldown != 0)
		{
			cooldown--;
		}
	}
}
