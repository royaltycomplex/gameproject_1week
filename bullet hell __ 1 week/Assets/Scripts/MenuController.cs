using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour 
{

	public int cursorPosition;

	public int cursorLimit;
	public bool horizontal = false;

//	private GameObject cursor;
	private GameObject varHold;

	private GameObject gc;

	// Use this for initialization
	void Start () 
	{
		cursorPosition = cursorLimit;	
//		cursor = GameObject.Find("cursor");

		varHold = GameObject.FindWithTag("VariableHold");
		gc = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetButtonDown("Vertical") && horizontal == false)
		{
			cursorPosition += ((Mathf.FloorToInt(Input.GetAxis("Vertical"))) * 2) + 1;
			cursorPosition = Mathf.Clamp(cursorPosition, 0, cursorLimit);
//			print(Mathf.FloorToInt (Input.GetAxis("Vertical")));
		}

		if (Input.GetButtonDown("Horizontal") && horizontal == true)
		{
			cursorPosition -= ((Mathf.FloorToInt(Input.GetAxis("Horizontal"))) * 2) + 1;
			cursorPosition = Mathf.Clamp(cursorPosition, 0, cursorLimit);
			print(Mathf.FloorToInt (Input.GetAxis("Horizontal")));
		}

		if (Input.GetButtonDown("Fire1"))
		{
			if (SceneManager.GetActiveScene().name == "frontend")
			{
				if (cursorPosition == 2 || cursorPosition == 1) {varHold.GetComponent<VariableHold>().waveCount = 0;}
				if (cursorPosition == 0) {varHold.GetComponent<VariableHold>().waveCount = 9;}
				DontDestroyOnLoad(varHold);
				SceneManager.LoadScene("main");
			}
			if (SceneManager.GetActiveScene().name == "main")
			{
				if (cursorPosition == 1) {gc.GetComponent<GameController>().Continue(); gameObject.SetActive(false);}
				if (cursorPosition == 0) {gc.GetComponent<GameController>().gameOver = true; gameObject.SetActive(false);}
			}
		}


	}
}
