using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternC : MonoBehaviour 
{

	public GameObject[] bullets;

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
		spawnFrame = 10;
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
					Quaternion bulletRotation = defaultRotation * Quaternion.Euler (0.0f, 40.0f, 0.0f);
					Instantiate(bullets[0], transform.position + (transform.right * 0.0f), bulletRotation, enemyBullets.transform);
					spawnCount++;
				}
				else
				{
					Quaternion bulletRotation = defaultRotation * Quaternion.Euler (0.0f, -40.0f, 0.0f);
					Instantiate(bullets[1], transform.position - (transform.right * 0.0f), bulletRotation, enemyBullets.transform);
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
