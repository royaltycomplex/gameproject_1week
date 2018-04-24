using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveG : MonoBehaviour {

	public GameObject pattern;
	public float speed;
	public float rotate;
	
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
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
		{
			Instantiate(pattern, transform.position, transform.rotation, gameObject.transform);
		}
	}
}
