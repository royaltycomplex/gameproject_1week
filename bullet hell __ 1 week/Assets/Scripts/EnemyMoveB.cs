using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveB : MonoBehaviour {

	public GameObject pattern;
	public float speed;
	public float rotate;
	public int spawnFrame;

	private int waitToSpawn;

	private bool spawned = false;
	
	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		transform.Rotate(0.0f, rotate, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.position += -transform.forward * Time.deltaTime * speed;

		if (spawned)
			{
				if (waitToSpawn >= spawnFrame)
				{
					Instantiate(pattern, transform.position, transform.rotation, gameObject.transform);
					spawned = false;
					waitToSpawn = 0;
				}
				waitToSpawn++;
			}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
		{
			spawned = true;
		}
	}
}
