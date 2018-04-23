using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternA : MonoBehaviour {

	public GameObject bullet;

	private int waitToSpawn;
	private int maxBullets;
	private int spawnFrame;
	private int spawnCount;
	private int spawnMax;

	private GameObject enemyBullets;

	private Quaternion defaultRotation;
//	private int cooldown;

	// Use this for initialization
	void Start () {
		waitToSpawn = 0;
		maxBullets = 5;
		spawnFrame = 5;
		spawnCount = 0;
		spawnMax = 3;

		transform.Rotate(0.0f, -20.0f, 0.0f);
		defaultRotation = transform.rotation;

		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
//		cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnCount < spawnMax)
		{
			waitToSpawn++;
			if (waitToSpawn >= spawnFrame)
			{
				int i = 0;
				while (i < maxBullets)
				{
					bullet.GetComponent<Mover>().rotate = 0;
					if (spawnCount == 0)
					{
						bullet.GetComponent<Mover>().speed = 13;
					}
					else if (spawnCount == 1)
					{
						bullet.GetComponent<Mover>().speed = 11;
					}
					else
					{
						bullet.GetComponent<Mover>().speed = 9;
					}
					Instantiate(bullet, transform.position, transform.rotation, enemyBullets.transform);
					transform.Rotate(0.0f, 10.0f, 0.0f);
					i++;
				}
				i = 0;
				spawnCount++;
				waitToSpawn = 0;
				transform.rotation = defaultRotation;
			}
		}
		if (spawnCount == spawnMax)
		{
			Object.Destroy(this.gameObject);
		}
	}
}
