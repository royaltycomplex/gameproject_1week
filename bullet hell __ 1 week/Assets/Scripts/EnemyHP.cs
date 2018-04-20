using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

	public float hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player Bullet")
		{
			hp--;
			Destroy(other.gameObject);
		}
	}
}
