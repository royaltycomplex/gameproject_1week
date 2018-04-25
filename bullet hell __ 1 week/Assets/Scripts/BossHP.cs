using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour 
{

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
		percentage = (1.0f * hp[phaseCount]) / maxHP;
		bossHealthBar.GetComponent<RectTransform>().localScale = new Vector3(percentage, 1.0f, 1.0f);

		if (hp[phaseCount] <= 0)
		{
			foreach (Transform bullet in GetComponent<BossAPattern>().enemyBullets.transform)
			{
				Destroy(bullet.gameObject);
			}
			gc.AddScore (score[phaseCount]);
			if (phaseCount >= maxPhases - 1) {Destroy(gameObject);} else {phaseCount++; maxHP = hp[phaseCount];}
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Player Bullet")
		{
			gc.AddScore (10);
			hp[phaseCount]--;
			Destroy(other.gameObject);
		}

	}
}
