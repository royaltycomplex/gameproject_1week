using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAPatternC : MonoBehaviour 
{

	public GameObject[] bullets;

	private GameObject enemyBulletSpawn;

	private int waitToSpawn;
	private int spawnFrame;

	private float minRotate;
	private float maxRotate;

	private float rotate;

	// Use this for initialization
	void Start () 
	{
		enemyBulletSpawn = GameObject.FindWithTag("EnemyBulletSpawn");
		waitToSpawn = 0;
		spawnFrame = 2;
		rotate = 36.0f;
		transform.Rotate(0.0f, 10.0f, 0.0f);

		minRotate = -6.0f;
		maxRotate = 6.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (waitToSpawn >= spawnFrame)
		{
			int index = Random.Range(0, bullets.Length);
			bullets[index].GetComponent<Mover>().speed = 4.5f;
			bullets[index].GetComponent<Mover>().rotate = Random.Range(minRotate, maxRotate);
			Instantiate(bullets[index], transform.position - (transform.forward * 2.0f), transform.rotation, enemyBulletSpawn.transform);
			transform.Rotate(0.0f, rotate, 0.0f);
			waitToSpawn = 0;
		}
		waitToSpawn++;
	}
}
