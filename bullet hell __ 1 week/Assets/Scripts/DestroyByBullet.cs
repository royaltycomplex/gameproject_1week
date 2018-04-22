using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

	private bool lightDark;

	// Use this for initialization
	void Start () {
		lightDark = GetComponent<LightSwitch>().lightDark;
	}
	
	// Update is called once per frame
	void Update () {
		lightDark = GetComponent<LightSwitch>().lightDark;
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.tag == "Light Bullet" && !lightDark) || (other.tag == "Dark Bullet" && lightDark) || other.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}
}
