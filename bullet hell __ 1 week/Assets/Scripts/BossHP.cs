using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour 
{

	public GameObject explosion;

	public int[] hp;
	public int[] score;

	public int phaseCount;
	private int maxPhases;

	private int maxHP;
	private float percentage;

	private GameController gc;
	private GameObject bossHealthBar;

	// Use this for initialization
	void Start () 
	{
		phaseCount = 0;
		maxPhases = hp.Length;

		GameObject gcObject = GameObject.FindWithTag("GameController");
		if (gcObject != null) {gc = gcObject.GetComponent<GameController>();}
		bossHealthBar = GameObject.FindWithTag("BossHealthBar");

		maxHP = hp[phaseCount];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GetComponent<BossAPattern>().enabled == true)
		{
			percentage = (1.0f * hp[phaseCount]) / maxHP;
			bossHealthBar.GetComponent<RectTransform>().localScale = new Vector3(percentage, 1.0f, 1.0f);
		}

		if (hp[phaseCount] <= 0)
		{
			foreach (Transform bullet in GetComponent<BossAPattern>().enemyBullets.transform)
			{
				if (bullet != null)
				{
				explosion.transform.localScale = new Vector3 (0.025f, 0.025f, 0.025f);
				var ps = explosion.GetComponent<ParticleSystem>().main;
				ps.startSpeed = 15;
				ps.duration = 0.02f;
				ps.startColor = new Color(250.0f/255.0f, 167.0f/255.0f, 1.0f, 0.4f);
				Instantiate(explosion, bullet.transform.position, bullet.transform.rotation);
//				gc.AddScore(bullet.GetComponent<BossBulletScore>().score);
				Destroy(bullet.gameObject);
				}
			}
			gc.AddScore (score[phaseCount]);
			if (phaseCount >= maxPhases - 1)
			{
			gc.GetComponent<GameController>().levelComplete = true; 
			explosion.transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
			var ps = explosion.GetComponent<ParticleSystem>().main;
			ps.startSpeed = 8;
			ps.duration = 0.2f;
			ps.startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			explosion.GetComponent<AudioSource>().playOnAwake = true;
			explosion.GetComponent<AudioSource>().pitch = 0.35f;
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
			} 
			else {phaseCount++; maxHP = hp[phaseCount];}
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Player Bullet")
		{
			gc.AddScore (10);
			if (GetComponent<BossAPattern>().enabled == true) {hp[phaseCount]--;}
			explosion.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
			var ps = explosion.GetComponent<ParticleSystem>().main;
			ps.startSpeed = 15;
			ps.duration = 0.02f;
			ps.startColor = new Color(56.0f/255.0f, 156.0f/255.0f, 1.0f, 0.5f);
			explosion.GetComponent<AudioSource>().playOnAwake = false;
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}

	}
}
