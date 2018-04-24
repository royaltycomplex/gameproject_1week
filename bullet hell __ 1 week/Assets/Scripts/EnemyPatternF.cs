using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternF : MonoBehaviour
{

	public GameObject[] bullets;
	public int minRotate;
	public int maxRotate;

	private int waitToSpawn;
	private int spawnFrame;

	private GameObject enemyBullets;

	// Use this for initialization
	void Start () 
	{
		waitToSpawn = 0;
		spawnFrame = 5;

		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitToSpawn >= spawnFrame)
		{
			int rotate = Random.Range(minRotate, maxRotate);
			int index = Random.Range (0, bullets.Length);
			bullets[index].GetComponent<Mover>().rotate = rotate;
			Instantiate(bullets[index], transform.position, transform.rotation, enemyBullets.transform);
			waitToSpawn = 0;
		}
		waitToSpawn++;
	}
}