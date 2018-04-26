using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMover : MonoBehaviour 
{

	public float speed;
	public Vector3[] coords;

	private float maxMove;
	private float defX;

	private int oldPosition;
	private int newPosition;

	private GameObject menu;

	// Use this for initialization
	void Start () 
	{
		maxMove = 2.5f;
		defX = transform.position.x;

		menu = GameObject.Find("menu");
		oldPosition = menu.GetComponent<MenuController>().cursorPosition;
		newPosition = oldPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{

		newPosition = menu.GetComponent<MenuController>().cursorPosition;
		
		if (oldPosition != newPosition)
		{
			GetComponent<RectTransform>().localPosition = new Vector3 (coords[newPosition].x, coords[newPosition].y, coords[newPosition].z);

			GetComponent<AudioSource>().Play();

			defX = transform.position.x;
			oldPosition = newPosition;

		}

		if (transform.position.x < defX + maxMove) {transform.position += new Vector3 ((speed * Time.deltaTime), 0.0f, 0.0f);}
		else {transform.position = new Vector3 (defX, transform.position.y, transform.position.z);}


	}
}
