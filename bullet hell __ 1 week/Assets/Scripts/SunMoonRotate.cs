using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonRotate : MonoBehaviour 
{

	public float rotateSpeed;

	private GameObject player;

	private bool lightDark;
	private bool prevLightDark;

	private RectTransform selfRect;

	// Use this for initialization
	void Start () 
	{
		selfRect = GetComponent<RectTransform>();
		player = GameObject.FindWithTag ("Player");
		if (player != null)	{lightDark = player.GetComponent<LightSwitch>().lightDark;}
		prevLightDark = lightDark;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player != null)	{lightDark = player.GetComponent<LightSwitch>().lightDark;}
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
//		print(selfRect.rotation.z);
	}
}
