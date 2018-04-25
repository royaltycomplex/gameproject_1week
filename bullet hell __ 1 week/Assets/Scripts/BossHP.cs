using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour 
{

	public int[] hp;
	public int[] score;

	public int phaseCount;
	private int maxPhases;

	private GameController gc;

	// Use this for initialization
	void Start () 
	{
		phaseCount = 0;
		maxPhases = hp.Length;

		GameObject gcObject = GameObject.FindWithTag("GameController");
		if (gcObject != null) {gc = gcObject.GetComponent<GameController>();}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (hp[phaseCount] <= 0)
		{
			gc.AddScore (score[phaseCount]);
			if (phaseCount >= maxPhases) {Destroy(gameObject);} else {phaseCount++;}
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
