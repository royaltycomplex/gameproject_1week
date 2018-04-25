using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsScreen : MonoBehaviour 
{

	public int levelCompleteScore;

	private int score;
	private int lives;
	private int continues;
	private int levelcomplete;
	private int totalscore;

	private GameObject gc;
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		gc = GameObject.FindWithTag("GameController");
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gc != null && player != null)
		{
			score = gc.GetComponent<GameController>().score;
			lives = player.GetComponent<PlayerController>().lives * 100;
			continues = gc.GetComponent<GameController>().continues * 500;

			if (gc.GetComponent<GameController>().levelComplete) {levelcomplete = levelCompleteScore;} else {levelcomplete = 0;}
		}

		totalscore = (score + lives - continues + levelcomplete);

		transform.GetChild(0).GetComponent<Text>().text = "" + score;
		transform.GetChild(1).GetComponent<Text>().text = "" + lives;
		transform.GetChild(2).GetComponent<Text>().text = "" + continues;
		transform.GetChild(3).GetComponent<Text>().text = "" + levelcomplete;
		transform.GetChild(4).GetComponent<Text>().text = "" + totalscore;


		if (player != null && (gc.GetComponent<GameController>().levelComplete == true || gc.GetComponent<GameController>().gameOver == true))
		{
			Destroy(player.gameObject);
		}
		if (Input.GetButtonDown("Fire1"))
		{
			if (totalscore > PlayerPrefs.GetInt("High Score")) {PlayerPrefs.SetInt("High Score", totalscore);}
			SceneManager.LoadScene("frontend");
		}
	}
}
