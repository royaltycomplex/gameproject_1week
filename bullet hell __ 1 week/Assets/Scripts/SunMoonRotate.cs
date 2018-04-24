using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunMoonRotate : MonoBehaviour 
{

	public float rotateSpeed;

	private GameObject player;
	private bool focus;

	private bool lightDark;
	private bool prevLightDark;

	private RectTransform selfRect;
	private GameObject moon;
	private GameObject sun;

	// Use this for initialization
	void Start () 
	{
		selfRect = GetComponent<RectTransform>();
		player = GameObject.FindWithTag ("Player");
		if (player != null)	{lightDark = player.GetComponent<LightSwitch>().lightDark; focus = player.GetComponent<LightSwitch>().focus;}
		prevLightDark = lightDark;
		moon = GameObject.Find("Moon");
		sun = GameObject.Find("Sun");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player != null)	{lightDark = player.GetComponent<LightSwitch>().lightDark; focus = player.GetComponent<LightSwitch>().focus;}
		if (prevLightDark != lightDark)
		{
			if (lightDark)
			{
				selfRect.rotation *= Quaternion.Euler (0.0f, 0.0f, -1.0f * rotateSpeed);
				if (selfRect.rotation.z <= 0.0f)
				{
					prevLightDark = lightDark;
				}
			}
			if (!lightDark)
			{
				selfRect.rotation *= Quaternion.Euler (0.0f, 0.0f, 1.0f * rotateSpeed);
				if (selfRect.rotation.z >= 1.0f)
				{
					prevLightDark = lightDark;
				}
			}
		}
		else if (prevLightDark == lightDark)
		{
			if (selfRect.rotation.z > 0.0f && lightDark)
			{
				selfRect.rotation *= Quaternion.Euler (0.0f, 0.0f, -1.0f * rotateSpeed);
			}
			if (selfRect.rotation.z < 1.0f && !lightDark)
			{
				selfRect.rotation *= Quaternion.Euler (0.0f, 0.0f, 1.0f * rotateSpeed);
			}
		}
		if (focus)
		{
			moon.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			sun.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		}
		else if (!focus)
		{
			moon.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1);
			sun.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1);
		}
//		print(selfRect.rotation.z);
	}
}
