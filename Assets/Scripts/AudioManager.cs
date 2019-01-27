using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	public static AudioManager instance;
	public AudioSource source;
	void Awake () {
		instance=this;
	}
	public AudioClip addline;
	public AudioClip removeline;
	public AudioClip linehurtfrombullet;
	public AudioClip matrixhurt;


	public AudioClip BGM;

}
