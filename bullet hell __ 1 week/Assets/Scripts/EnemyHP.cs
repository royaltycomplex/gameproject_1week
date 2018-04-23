using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

	public float hp;
	public int scoreValue;

	private GameController gc;

	// Use this for initialization
	void Start () {
		GameObject gcObject = GameObject.FindWithTag ("GameController");
		if (gcObject != null)
		{
			gc = gcObject.GetComponent<GameController>();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hp <= 0)
		{
			gc.AddScore (scoreValue);
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
