using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

	// Use this for initialization
	public float destroyTime;
	private float curentTime=0;

	// Update is called once per frame
	void Update () {
		if(curentTime>-1)
		{
			curentTime+=Time.deltaTime;
		}
		if(curentTime>destroyTime)
		{
			Destroy(gameObject);
			curentTime=-1;
		}
	}
}
