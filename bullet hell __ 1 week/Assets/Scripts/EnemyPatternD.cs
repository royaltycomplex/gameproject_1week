using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternD : MonoBehaviour 
{

	public GameObject bullet;

	private int waitToSpawn;
	private int spawnFrame;

	private GameObject enemyBullets;

	// Use this for initialization
	void Start () 
	{
		waitToSpawn = 0;
		spawnFrame = 10;

		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitToSpawn >= spawnFrame)
		{
			Instantiate(bullet, transform.position, transform.rotation, enemyBullets.transform);
			waitToSpawn = 0;
		}
		waitToSpawn++;
	}
}
