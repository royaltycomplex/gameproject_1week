using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

	public GameObject explosion;

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
			explosion.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			var ps = explosion.GetComponent<ParticleSystem>().main;
			ps.startSpeed = 10;
			ps.duration = 0.1f;
			ps.startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			explosion.GetComponent<AudioSource>().playOnAwake = true;
			explosion.GetComponent<AudioSource>().pitch = 0.5f;
			Instantiate(explosion, transform.position, transform.rotation);

			gc.AddScore (scoreValue);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player Bullet")
		{
			gc.AddScore (5);
			hp--;
			explosion.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
			var ps = explosion.GetComponent<ParticleSystem>().main;
			ps.startSpeed = 15;
			ps.duration = 0.02f;
			ps.startColor = new Color(56.0f/255.0f, 156.0f/255.0f, 1.0f, 0.5f);
			explosion.GetComponent<AudioSource>().playOnAwake = false;
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
	}
}
