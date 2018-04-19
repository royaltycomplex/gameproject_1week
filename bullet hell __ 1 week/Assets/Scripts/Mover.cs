using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	private Rigidbody rb;

	public float speed;
	public float rotate;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		transform.Rotate(0.0f, rotate * Time.deltaTime, 0.0f);
		rb.position += -(transform.forward) * Time.deltaTime * speed;
	}
}
