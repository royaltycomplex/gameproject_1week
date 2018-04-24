using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

	private bool lightDark;
	private bool focus;

	// Use this for initialization
	void Start () {
		lightDark = GetComponent<LightSwitch>().lightDark;
		focus = GetComponent<LightSwitch>().focus;
	}
	
	// Update is called once per frame
	void Update () {
		lightDark = GetComponent<LightSwitch>().lightDark;
		focus = GetComponent<LightSwitch>().focus;
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.tag == "Light Bullet" && !lightDark) || (other.tag == "Dark Bullet" && lightDark) || other.tag == "Enemy" || other.tag == "Neutral Bullet" || focus == true)
		{
			Destroy(gameObject);
		}
	}
}
