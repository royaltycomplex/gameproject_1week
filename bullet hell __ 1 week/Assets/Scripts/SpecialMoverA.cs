using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMoverA : MonoBehaviour 
{

	public float rotateSpeed;

	private int waitBeforeRotate;
	private int rotateFrame;
	private Quaternion initRotation;

	private float minRotate;
	private float maxRotate;

	private bool rotateOnce = false;

	private bool rotateToMax = false;
	private bool rotateToMin = false;

	void Start ()
	{
		initRotation = transform.rotation;
		waitBeforeRotate = 0;
		rotateFrame = 5;

		if (initRotation.y > 0)
		{
			maxRotate = initRotation.y;
			minRotate = -initRotation.y;
		}
		else if (initRotation.y < 0)
		{
			maxRotate = -initRotation.y;
			minRotate = initRotation.y;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitBeforeRotate >= rotateFrame)
		{	
			if (transform.rotation.y > minRotate && rotateToMax == false)
			{
				rotateToMin = true;
			}
			else if (transform.rotation.y < maxRotate && rotateToMin == false)
			{
				rotateToMax = true;
			}
			if ((transform.rotation.y <= minRotate && rotateToMin) || (transform.rotation.y >= maxRotate && rotateToMax))
			{
				rotateToMax = false;
				rotateToMin = false;
				if (rotateOnce == false)
				{
					rotateFrame *= 2;
					rotateOnce = true;
				}
				waitBeforeRotate = 0;
			}

			if (rotateToMin)
			{
				transform.rotation *= Quaternion.Euler (0.0f, -1.0f * rotateSpeed, 0.0f);
			}
			else if (rotateToMax)
			{
				transform.rotation *= Quaternion.Euler (0.0f, 1.0f * rotateSpeed, 0.0f);
			}
		}
		waitBeforeRotate++;
	}
}
