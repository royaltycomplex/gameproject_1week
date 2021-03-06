﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTint : MonoBehaviour {

	private bool lightDark;
	private bool focus;
	private GameObject player;

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponentInChildren<Renderer>();
		player = GameObject.FindWithTag("Player");	
		if (player != null)
		{
			lightDark = player.GetComponent<LightSwitch>().lightDark;
			focus = player.GetComponent<LightSwitch>().focus;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null)
		{
			lightDark = player.GetComponent<LightSwitch>().lightDark;
			focus = player.GetComponent<LightSwitch>().focus;
		}

		if (gameObject.tag == "Light Bullet" && lightDark && !focus)
		{
			rend.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.35f));
		}
		else if (gameObject.tag == "Dark Bullet" && !lightDark && !focus)
		{
			rend.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.35f));
		}
		else
		{
			rend.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 1));
		}
	}
}
