using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternB : MonoBehaviour {

	public GameObject bullet;

	private int waitToSpawn;
	private int spawnFrame;
	private int maxBullets;
	private int spawnCount;
	private int spawnMax;

	private GameObject enemyBullets;
	private Quaternion defaultRotation;
	// Use this for initialization
	void Start () 
	{
		defaultRotation = transform.rotation;
		enemyBullets = GameObject.Find("EnemyBullets");

		waitToSpawn = 0;
		spawnFrame = 8;
		spawnMax = 1;
		maxBullets = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitToSpawn >= spawnFrame)
		{
			int i = 0;
			while (i < maxBullets)
			{
				if (spawnCount < spawnMax)
				{
					Quaternion bulletRotation = defaultRotation * Quaternion.Euler (0.0f, 115.0f, 0.0f);
					Instantiate(bullet, transform.position - (transform.right * 1.5f), bulletRotation, enemyBullets.transform);
					spawnCount++;
				}
				else
				{
					Quaternion bulletRotation = defaultRotation * Quaternion.Euler (0.0f, -115.0f, 0.0f);
					Instantiate(bullet, transform.position + (transform.right * 1.5f), bulletRotation, enemyBullets.transform);
					spawnCount = 0;
				}
				i++;
			}
			i = 0;
			waitToSpawn = 0;
		}
		waitToSpawn++;
	}
}
