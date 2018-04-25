using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text livesText;
	public int score;

	private GameObject player;
	private int livesUpValue;
	private int livesUpScore;


	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore();

		player = GameObject.FindWithTag("Player");
		livesUpValue = 100000;
		livesUpScore = score;
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives;}

		if (livesUpScore >= livesUpValue) 
		{
				if (player != null) {player.GetComponent<PlayerController>().lives++;}
				livesUpScore = livesUpScore - livesUpValue;
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		livesUpScore += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "" + score;
	}
}
