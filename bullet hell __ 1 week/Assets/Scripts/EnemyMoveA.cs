using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveA : MonoBehaviour 
{

	public GameObject pattern;
	public float speed;
	public float rotate;

	private int moveBeforeShoot;
	private int waitWhileShoot;
	private int frameCounter = 0;
	private bool shoot = false;
	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		transform.Rotate(0.0f, rotate, 0.0f);
		moveBeforeShoot = 120;
		waitWhileShoot = 145;
//		Instantiate(pattern, rb.position, rb.rotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!shoot)
		{
			if (frameCounter < moveBeforeShoot)
			{
				rb.position += -transform.forward * Time.deltaTime * speed;
				frameCounter++;
			}
			else
			{
				Instantiate(pattern, rb.position - (transform.forward * 1.5f), rb.rotation, transform.parent);
				frameCounter = 0;
				shoot = true;
			}
		}
		else
		{
			if (frameCounter < waitWhileShoot)
			{
				frameCounter++;
			}
			else
			{
				frameCounter = 0;
				shoot = false;
			}
		}
	}
}
