using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfOut : MonoBehaviour 
{

	private int waitToCheck;
	private int checkFrame;

	// Use this for initialization
	void Start () 
	{
		waitToCheck = 0;
		checkFrame = 3600;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitToCheck >= checkFrame)
		{
			if (transform.position.x > 12 || transform.position.x < -12 || transform.position.z > 28 || transform.position.z < -4)
			{
				Destroy(gameObject);
			}
		}
		waitToCheck++;
	}


}
