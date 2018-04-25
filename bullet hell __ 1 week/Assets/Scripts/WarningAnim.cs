using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningAnim : MonoBehaviour 
{

	public float enhanceRate;

	private bool warningFlash = false;

	private int waitToDestroy;
	private int destroyFrame;

	private GameObject levelController;

	// Use this for initialization
	void Start () 
	{
		waitToDestroy = 0;
		destroyFrame = 240;

		levelController = GameObject.FindWithTag("LevelController");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!warningFlash)
		{
			GetComponent<RectTransform>().localScale += new Vector3(enhanceRate, enhanceRate, 0.0f);
			if (GetComponent<RectTransform>().localScale == new Vector3(1.0f, 1.0f, 1.0f)) {warningFlash = true;}
		}

		if (warningFlash)
		{
			if (waitToDestroy % 64 == 0) {transform.GetChild(0).GetComponent<Image>().enabled = false;} else if (waitToDestroy % 64 == 32) {transform.GetChild(0).GetComponent<Image>().enabled = true;}
			waitToDestroy++;
		}

		if (waitToDestroy >= destroyFrame) 
		{
			levelController.GetComponent<LevelAController>().bossSpawn.GetComponent<BossAPattern>().enabled = true;
			Destroy(levelController.gameObject);
			Destroy(gameObject);
		}
	}
}
