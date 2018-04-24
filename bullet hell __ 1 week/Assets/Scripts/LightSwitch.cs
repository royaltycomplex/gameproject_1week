using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour 
{

	public bool lightDark = false;
	public bool focus = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2"))
		{
			lightDark = !lightDark;
		}
		if (Input.GetButton ("Fire3"))
		{
			focus = true;
		}
		else
		{
			focus = false;
		}
	}
}
