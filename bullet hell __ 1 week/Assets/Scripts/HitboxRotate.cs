﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxRotate : MonoBehaviour 
{

	public float speed;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(0.0f, 0.0f, 1.0f * speed * Time.deltaTime);
	}
}
