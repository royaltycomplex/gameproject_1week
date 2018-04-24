using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text livesText;
	public int score;

	private GameObject player;
	private bool livesUp = false;
	private int livesUpValue;
	private int livesUpScore;


	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore();

		player = GameObject.FindWithTag("Player");
		livesUpValue = 1000000;
		livesUpScore = score;
	}
	
	// Update is called once per frame
	void Update () {

		livesText.text = "Lives: " + player.GetComponent<PlayerController>().lives;

		if ((score % livesUpValue) <= (livesUpValue / 5) && (score > livesUpValue - 1)) 
		{
			if (!livesUp)
			{
				if (player != null) {player.GetComponent<PlayerController>().lives++;}
				livesUp = true;
				livesUpScore = score;
			}
		}
		else if (livesUpScore != score) {livesUp = false;}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "" + score;
	}
}
