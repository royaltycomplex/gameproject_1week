using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossABulletA : MonoBehaviour {

	public float speed;
	public float rotate;
//	public GameObject spawnPoint;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		transform.Rotate(0.0f, rotate * Time.deltaTime, 0.0f);
		rb.position += -(transform.forward) * Time.deltaTime * speed;
	}
}
