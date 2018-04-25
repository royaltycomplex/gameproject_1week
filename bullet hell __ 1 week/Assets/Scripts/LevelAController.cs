using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAController : MonoBehaviour 
{

	public GameObject[] enemies;
	public GameObject boss;

	private float scrollSpeed;
	private GameObject bg;

	private bool spawnBoss = false;
	private bool bossSpawned = false;
	public GameObject bossSpawn;

	private int waveCount = 0;
	private int waitToWave;
	private int waveFrame;

	private GameObject enemySpawn;
	private GameObject enemyBullets;
	private GameObject bossWarning;
	private GameObject bossHealthBar;
	private GameObject varHold;

	private float bossHealthGrow;

	// Use this for initialization
	void Start () 
	{
		bg = GameObject.FindWithTag("Background");
		scrollSpeed = 0.0065f;
		waitToWave = 0;
		waveFrame = 120;

		enemySpawn = GameObject.FindWithTag("EnemySpawn");
		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
		bossWarning = GameObject.FindWithTag("Warning");
		bossHealthBar = GameObject.FindWithTag("BossHealthBar");
		bossHealthBar.GetComponent<RectTransform>().localScale = new Vector3 (0.0f, 1.0f, 1.0f);
		bossWarning.SetActive(false);

		varHold = GameObject.FindWithTag("VariableHold");
		if (varHold != null) {waveCount = varHold.GetComponent<VariableHold>().waveCount;}
		Destroy(varHold);

		bossHealthGrow = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bg.transform.position -= new Vector3 (0.0f, 0.0f, scrollSpeed);

		if (waitToWave >= waveFrame)
		{
			WaveSpawn(waveCount);
			waveCount++;
		}

		if (waveCount < 10) {waitToWave++;}

		if (spawnBoss) 
		{
			if (bossHealthBar.GetComponent<RectTransform>().localScale.x < 1.0f) 
			{
				bossHealthGrow += 0.025f;
				bossHealthBar.GetComponent<RectTransform>().localScale = new Vector3(bossHealthGrow, 1.0f, 1.0f);
			}
			else {bossHealthBar.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);}

			if (!bossSpawned) {bossSpawn = Instantiate(boss, new Vector3 (0.0f, 5.0f, 30.0f), transform.rotation); bossSpawned = true;}
			if (bossSpawned && bossSpawn.transform.position.z != 24.0f) {bossSpawn.transform.position -= new Vector3 (0.0f, 0.0f, 0.025f);}
		}

	}
	
	void WaveSpawn (int count)
	{

		if (count == 0)
		{
			enemies[8].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[8], new Vector3(-20.0f, 5.0f, 25.0f), transform.rotation, enemySpawn.transform);
			enemies[8].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[8], new Vector3(40.0f, 5.0f, 20.0f), transform.rotation, enemySpawn.transform);
			enemies[8].GetComponent<EnemyMoveB>().rotate = 30.0f;
			Instantiate(enemies[8], new Vector3(10.5f, 5.0f, 40.0f), transform.rotation, enemySpawn.transform);

			waveFrame = 220;
		}

		if (count == 1)
		{
			Instantiate(enemies[5], new Vector3(-20.0f, 5.0f, 50.0f), transform.rotation * Quaternion.Euler (0.0f, -45.0f, 0.0f), enemySpawn.transform);
			Instantiate(enemies[5], new Vector3(7.5f, 5.0f, 65.5f), transform.rotation * Quaternion.Euler (0.0f, 20.0f, 0.0f), enemySpawn.transform);

			waveFrame = 240;
		}

		if (count == 2)
		{
			enemies[8].GetComponent<EnemyMoveB>().rotate = -40.0f;
			Instantiate(enemies[8], new Vector3(-25.0f, 5.0f, 50.0f), transform.rotation, enemySpawn.transform);
			enemies[8].GetComponent<EnemyMoveB>().rotate = 40.0f;
			Instantiate(enemies[8], new Vector3(15.0f, 5.0f, 40.0f), transform.rotation, enemySpawn.transform);

			enemies[2].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[2], new Vector3(-20.0f, 5.0f, 20.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[3], new Vector3(20.0f, 5.0f, 18.0f), transform.rotation, enemySpawn.transform);

			waveFrame = 420;
		}

		if (count == 3)
		{
			Instantiate(enemies[4], new Vector3(-10.0f, 5.0f, 40.0f), transform.rotation, enemySpawn.transform);
			Instantiate(enemies[4], new Vector3(-5.0f, 5.0f, 45.0f), transform.rotation, enemySpawn.transform);
			Instantiate(enemies[4], new Vector3(-0.0f, 5.0f, 50.0f), transform.rotation, enemySpawn.transform);
			Instantiate(enemies[4], new Vector3(5.0f, 5.0f, 55.0f), transform.rotation, enemySpawn.transform);
			Instantiate(enemies[4], new Vector3(10.0f, 5.0f, 60.0f), transform.rotation, enemySpawn.transform);

			scrollSpeed = 0.0185f;

			waveFrame = 550;

		}

		if (count == 4)
		{

			enemies[2].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[2], new Vector3(-20.0f, 5.0f, 16.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[3], new Vector3(20.0f, 5.0f, 13.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[3], new Vector3(-60.0f, 5.0f, 19.0f), transform.rotation, enemySpawn.transform);
			enemies[2].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[2], new Vector3(60.0f, 5.0f, 10.0f), transform.rotation, enemySpawn.transform);

			enemies[2].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[2], new Vector3(-160.0f, 5.0f, 16.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[3], new Vector3(160.0f, 5.0f, 13.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[3], new Vector3(-200.0f, 5.0f, 22.0f), transform.rotation, enemySpawn.transform);
			enemies[2].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[2], new Vector3(200.0f, 5.0f, 10.0f), transform.rotation, enemySpawn.transform);

			enemies[2].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[2], new Vector3(-185.0f, 5.0f, 20.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[3], new Vector3(185.0f, 5.0f, 24.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[3], new Vector3(-220.0f, 5.0f, 10.0f), transform.rotation, enemySpawn.transform);
			enemies[2].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[2], new Vector3(220.0f, 5.0f, 15.0f), transform.rotation, enemySpawn.transform);

			waveFrame = 320;

		}

		if (count == 5)
		{
			Instantiate(enemies[5], new Vector3(-20.0f, 5.0f, 15.0f), transform.rotation * Quaternion.Euler (0.0f, -105.0f, 0.0f), enemySpawn.transform);
//			Instantiate(enemies[5], new Vector3(7.5f, 5.0f, 10.5f), transform.rotation * Quaternion.Euler (0.0f, 110.0f, 0.0f), enemySpawn.transform);

			waveFrame = 240;
		}

		if (count == 6)
		{
			Instantiate(enemies[0], new Vector3(-45.0f, 5.0f, 45.0f), transform.rotation * Quaternion.Euler (0.0f, -25.0f, 0.0f), enemySpawn.transform);
			Instantiate(enemies[1], new Vector3(45.0f, 5.0f, 75.0f), transform.rotation * Quaternion.Euler (0.0f, 30.0f, 0.0f), enemySpawn.transform);
			Instantiate(enemies[0], new Vector3(-20.0f, 5.0f, 100.0f), transform.rotation * Quaternion.Euler (0.0f, -15.0f, 0.0f), enemySpawn.transform);
			Instantiate(enemies[1], new Vector3(35.0f, 5.0f, 105.0f), transform.rotation * Quaternion.Euler (0.0f, 18.0f, 0.0f), enemySpawn.transform);

			waveFrame = 220;
		}

		if (count == 7)
		{
			enemies[7].GetComponent<EnemyMoveF>().rotate = 0.5f;
			Instantiate(enemies[7], new Vector3(-20.0f, 5.0f, 45.0f), transform.rotation * Quaternion.Euler (0.0f, -25.0f, 0.0f), enemySpawn.transform);
			enemies[7].GetComponent<EnemyMoveF>().rotate = -0.5f;
			Instantiate(enemies[7], new Vector3(30.0f, 5.0f, 75.0f), transform.rotation * Quaternion.Euler (0.0f, 20.0f, 0.0f), enemySpawn.transform);

			waveFrame = 70;
		}

		if (count == 8)
		{
			enemies[6].GetComponent<EnemyMoveE>().rotate = 0.5f;
			Instantiate(enemies[6], new Vector3(-15.0f, 5.0f, 45.0f), transform.rotation * Quaternion.Euler (0.0f, -15.0f, 0.0f), enemySpawn.transform);
			enemies[6].GetComponent<EnemyMoveE>().rotate = -0.5f;
			Instantiate(enemies[6], new Vector3(15.0f, 5.0f, 55.0f), transform.rotation * Quaternion.Euler (0.0f, 15.0f, 0.0f), enemySpawn.transform);

			enemies[3].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[3], new Vector3(-55.0f, 5.0f, 16.0f), transform.rotation, enemySpawn.transform);
			enemies[2].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[2], new Vector3(55.0f, 5.0f, 13.0f), transform.rotation, enemySpawn.transform);

			enemies[2].GetComponent<EnemyMoveB>().rotate = -90.0f;
			Instantiate(enemies[2], new Vector3(-135.0f, 5.0f, 19.0f), transform.rotation, enemySpawn.transform);
			enemies[3].GetComponent<EnemyMoveB>().rotate = 90.0f;
			Instantiate(enemies[3], new Vector3(135.0f, 5.0f, 10.0f), transform.rotation, enemySpawn.transform);

			waveFrame = 1595;

		}


		if (count == 9) 
		{
			foreach (Transform child in enemyBullets.transform)
			{
 			    GameObject.Destroy(child.gameObject);
 			}
			scrollSpeed = 0.0f;
			bg.transform.position = new Vector3 (0.0f, -50.0f, 5.0f);
			spawnBoss = true;
			bossWarning.SetActive(true);


		}

		waitToWave = 0;

	}


}
