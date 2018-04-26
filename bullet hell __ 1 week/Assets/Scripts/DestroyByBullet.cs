﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

	public GameObject explosion;

	private bool lightDark;
	private bool focus;
	private int lives;

	private GameObject levelController;
	private GameObject enemySpawn;
	private GameObject enemyBullets;
	private GameObject playerBullets;
	private GameObject boss;
//	private GameObject player;

//	private GameObject pause;
	private GameObject continueMenu;

//	private GameObject gc;

	// Use this for initialization
	void Start () {
		lightDark = GetComponent<LightSwitch>().lightDark;
		focus = GetComponent<LightSwitch>().focus;
		lives = GetComponent<PlayerController>().lives;

		levelController = GameObject.FindWithTag("LevelController");
		enemySpawn = GameObject.FindWithTag("EnemySpawn");
		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
		playerBullets = GameObject.FindWithTag("PlayerBulletSpawn");
//		player = GameObject.FindWithTag("Player");
//		pause = GameObject.FindWithTag("Pause");
		continueMenu = GameObject.FindWithTag("Continue");

//		gc = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		continueMenu.SetActive(false);

		lightDark = GetComponent<LightSwitch>().lightDark;
		focus = GetComponent<LightSwitch>().focus;
		lives = GetComponent<PlayerController>().lives;
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.tag == "Light Bullet" && !lightDark) || (other.tag == "Dark Bullet" && lightDark) || other.tag == "Enemy" || other.tag == "Neutral Bullet" || focus == true)
		{
			explosion.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			var ps = explosion.GetComponent<ParticleSystem>().main;
			ps.startSpeed = 10;
			ps.duration = 0.1f;
			ps.startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			explosion.GetComponent<AudioSource>().playOnAwake = true;
			explosion.GetComponent<AudioSource>().pitch = 0.85f;
			Instantiate(explosion, transform.position, transform.rotation);

			if (lives > 0)
			{
				transform.position = new Vector3(0.0f, 0.0f, 0.0f);
				GetComponent<PlayerController>().lives--;
				GetComponent<PlayerController>().respawning = true;
			}
			else 
			{
				if (levelController != null) {levelController.SetActive(false);}
				boss = GameObject.FindWithTag("Boss");
				if (boss != null) {boss.SetActive(false);}
				enemySpawn.SetActive(false); enemyBullets.SetActive(false); playerBullets.SetActive(false); continueMenu.SetActive(true); gameObject.SetActive(false);
				continueMenu.GetComponent<MenuController>().cursorPosition = continueMenu.GetComponent<MenuController>().cursorLimit;
			}

		}
	}
}
