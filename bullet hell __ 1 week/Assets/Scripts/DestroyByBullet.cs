using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

	private bool lightDark;
	private bool focus;
	private int lives;

	private GameObject gc;

	// Use this for initialization
	void Start () {
		lightDark = GetComponent<LightSwitch>().lightDark;
		focus = GetComponent<LightSwitch>().focus;
		lives = GetComponent<PlayerController>().lives;
		gc = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		lightDark = GetComponent<LightSwitch>().lightDark;
		focus = GetComponent<LightSwitch>().focus;
		lives = GetComponent<PlayerController>().lives;
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.tag == "Light Bullet" && !lightDark) || (other.tag == "Dark Bullet" && lightDark) || other.tag == "Enemy" || other.tag == "Neutral Bullet" || focus == true)
		{
			if (lives > 0)
			{
				transform.position = new Vector3(0.0f, 0.0f, 0.0f);
				GetComponent<PlayerController>().lives--;
				GetComponent<PlayerController>().respawning = true;
			}
			else {Destroy(gameObject);}
		}
	}
}
