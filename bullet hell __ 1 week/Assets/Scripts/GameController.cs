using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	public Text livesText;
	public int score;

	private int highScore;

	public GameObject playerObject;

	private GameObject player;
	private int livesUpValue;
	private int livesUpScore;

	public int continues;

	private GameObject levelController;
	private GameObject enemySpawn;
	private GameObject enemyBullets;
	private GameObject playerBullets;

	private GameObject pause;
	private GameObject continueMenu;
	private GameObject resultsMenu;

	public bool levelComplete = false;
	public bool gameOver = false;

	// Use this for initialization
	void Start () {
		continues = 0;
		score = 0;
		UpdateScore();

		highScore = PlayerPrefs.GetInt("High Score");

		highScoreText.text = "" + highScore;


		player = GameObject.FindWithTag("Player");
		livesUpValue = 100000;
		livesUpScore = score;


		levelController = GameObject.FindWithTag("LevelController");
		enemySpawn = GameObject.FindWithTag("EnemySpawn");
		enemyBullets = GameObject.FindWithTag("EnemyBulletSpawn");
		playerBullets = GameObject.FindWithTag("PlayerBulletSpawn");
		pause = GameObject.FindWithTag("Pause");
		continueMenu = GameObject.FindWithTag("Continue");
		resultsMenu = GameObject.Find("Results");

		resultsMenu.SetActive(false);
		pause.SetActive(false);
		continueMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if ((levelComplete || gameOver) && !resultsMenu.activeInHierarchy)
		{
			resultsMenu.SetActive(true);
		}

		if (player != null) {livesText.text = "" + player.GetComponent<PlayerController>().lives;}

		if (livesUpScore >= livesUpValue) 
		{
				if (player != null) {player.GetComponent<PlayerController>().lives++;}
				livesUpScore = livesUpScore - livesUpValue;
		}

//		if (Input.GetButtonDown("Submit"))
//		{
//			
//			
//			pause.SetActive(!pause.activeInHierarchy);
//			if (pause.activeInHierarchy && !continueMenu.activeInHierarchy)
//			{
//				Time.timeScale = 0; 
//				levelController.SetActive(false);
//				enemySpawn.SetActive(false);
//				GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Pattern");
//     
//    			 for(int i = 0 ; i < gameObjects.Length ; i ++)
  //  			 {
    //		  	   Destroy(gameObjects[i]);
    //			 }
	//			enemyBullets.SetActive(false); playerBullets.SetActive(false); player.SetActive(false);
	//		}
	//		else if (!pause.activeInHierarchy && !continueMenu.activeInHierarchy)
	//		{
	//			Time.timeScale = 1;
	//			levelController.SetActive(true); 
	//			enemySpawn.SetActive(true); 
	//			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Pattern");
     //
    	//		 for(int i = 0 ; i < gameObjects.Length ; i ++)
    	//		 {
    	//	  	   Destroy(gameObjects[i]);
    	//		 }
	//			enemyBullets.SetActive(true); playerBullets.SetActive(true); player.SetActive(true);
	//		}
	//	}



	}

	public void Continue ()
	{
		continues++;
		player.SetActive(true);
		player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
		player.GetComponent<PlayerController>().respawning = true;
		player.GetComponent<PlayerController>().lives = 5;
		levelController.SetActive(true); enemySpawn.SetActive(true); enemyBullets.SetActive(true); playerBullets.SetActive(true); continueMenu.SetActive(false);
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Pattern");
     
		for(int i = 0 ; i < gameObjects.Length ; i ++)
		{
			Destroy(gameObjects[i]);
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
		if (score > highScore) {highScore = score; highScoreText.text = "" + highScore;}
	}
}
