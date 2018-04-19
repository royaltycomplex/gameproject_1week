using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrototypeController : MonoBehaviour {

	private int waitToSpawn = 0;
	private int spawnCount = 25;
	private int cooldown = 0;
	private float rotateRef;

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		rotateRef = bullet.GetComponent<Mover>().rotate;
	}
	
	// Update is called once per frame
	void Update () {
		waitToSpawn ++;
		if (waitToSpawn >= spawnCount)
		{
			waitToSpawn = 0;
			//if (cooldown == 0) {Pattern5();};
			Pattern3();
		}
		if (cooldown != 0)
		{
			cooldown--;
		}
	}

	void Pattern1 ()
	{
			bullet.GetComponent<Mover>().rotate = 0;
			int i = 1;
			while (i < 21)
			{
				Instantiate(bullet, transform.position, transform.rotation);
				transform.Rotate(0.0f, 18.0f, 0.0f);
				i++;
			}
			bullet.GetComponent<Mover>().rotate = rotateRef;
			i = 0;
	}

	void Pattern2 ()
	{
			int i = 1;
			while (i < 10)
			{
				Instantiate(bullet, transform.position, transform.rotation);
				transform.Rotate(0.0f, 18.0f, 0.0f);
				i++;
			}
			i = 0;
	}

	void Pattern3 ()
	{
			int i = 1;
			while (i < 21)
			{
				Instantiate(bullet, transform.position, transform.rotation);
				transform.Rotate(0.0f, 18.0f, 0.0f);
				i++;
			}
			i = 0;
	}

	void Pattern4 ()
	{
			Instantiate(bullet, transform.position, transform.rotation);
			transform.Rotate(0.0f, 18.0f, 0.0f);
	}

	void Pattern5 ()
	{
			int i = 1;
			while (i < 21)
			{

				Instantiate(bullet, transform.position, transform.rotation);
				transform.Rotate(0.0f, 18.0f, 0.0f);
				i++;
			}
			i = 0;
			cooldown = 60;
	}
}
