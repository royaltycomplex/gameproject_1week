using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour 
{

	public AudioSource switchSound;
	public bool lightDark = false;
	public bool focus = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire3"))
		{
			lightDark = !lightDark;
			switchSound.Play();
		}
		if (Input.GetButton ("Fire2"))
		{
			focus = true;
		}
		else
		{
			focus = false;
		}
	}
}
