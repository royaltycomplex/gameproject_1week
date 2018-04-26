using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour {


	public AudioSource intro;
	public AudioSource loop;

	private int frameCount;
	private int playFrame;

	public bool continueMenu = false;
	public bool boss = false;

	private GameObject continueMenuObject;

	private float volumeLevel;

	// Use this for initialization
	void Start () 
	{
		frameCount = 0;
		playFrame = 447;
		volumeLevel = 0.7f;

		continueMenuObject = GameObject.FindWithTag("Continue");
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (frameCount == 0) {intro.Play();}
		if (!loop.isPlaying)
		{
			loop.volume = 0.6f;
			loop.Play();
		}

		if (continueMenuObject != null)
		{
			if (continueMenuObject.activeInHierarchy) {continueMenu = true;}
			else {continueMenu = false;}
		}

		if (continueMenu) {loop.volume = volumeLevel / 2;} else if (!boss) {loop.volume = volumeLevel;}

		if (boss) {loop.volume -= 0.005f;}
		if (loop.volume == 0.0f) {Destroy(gameObject);}

//		else {frameCount++;}
	}
}
