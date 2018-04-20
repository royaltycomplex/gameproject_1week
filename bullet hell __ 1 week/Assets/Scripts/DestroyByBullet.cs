﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Light Bullet" || other.tag == "Dark Bullet" || other.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}
}