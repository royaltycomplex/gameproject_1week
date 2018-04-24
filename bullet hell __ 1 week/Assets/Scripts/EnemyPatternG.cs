using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternG : MonoBehaviour 
{

	public GameObject[] bullets;
	public int minRotate;
	public int maxRotate;
	public float bulletSpeed;

	private int waitToSpawn;
	private int spawnFrame;
	private int maxBullets;

	private GameObject enemyBullets;

	// Use this for initialization
	void Start () 
	{
		waitToSpawn = 0;
		spawnFrame = 20;
		maxBullets = 4;

		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitToSpawn >= spawnFrame)
		{
			int i = 0;
			while (i < maxBullets)
			{
			int rotate = Random.Range(minRotate, maxRotate);
			int index = Random.Range (0, bullets.Length);
			bullets[index].GetComponent<Mover>().rotate = rotate;
			bullets[index].GetComponent<Mover>().speed = bulletSpeed;
			float bulletPosUp = 0.0f;
			float bulletPosRight = 0.0f;
			float bulletRotate = 0.0f;
			if (i == 0) {bulletPosUp = -0.4f; bulletPosRight = 1.4f; bulletRotate = -75.0f;}
			if (i == 1) {bulletPosUp = 0.6f; bulletPosRight = 1.4f; bulletRotate = -115.0f;}
			if (i == 2) {bulletPosUp = -0.4f; bulletPosRight = -1.4f; bulletRotate = 75.0f;}
			if (i == 3) {bulletPosUp = 0.6f; bulletPosRight = -1.4f; bulletRotate = 115.0f;}
			Instantiate(
			bullets[index],
			transform.position + (transform.forward * bulletPosUp) + (transform.right * bulletPosRight),
			transform.rotation * Quaternion.Euler (0.0f, bulletRotate, 0.0f),
			enemyBullets.transform
			);
			i++;
			}
			i = 0;
			waitToSpawn = 0;
		}
		waitToSpawn++;
	}
}