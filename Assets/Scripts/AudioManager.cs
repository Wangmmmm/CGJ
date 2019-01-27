using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	public static AudioManager instance;
	public AudioSource source;
	public AudioSource laserSource;
	void Awake () {
		instance=this;
		//source.Play();
	}
	public AudioClip addline;
	public AudioClip removeline;
	public AudioClip linehurtfrombullet;
	public AudioClip matrixhurt;

	public AudioClip matrixDes;
	public AudioClip laser;
	public AudioClip BGM;

	public void PlayAddLine()
	{
		source.PlayOneShot(addline);
	}
	public void PlayRemoveLine()
	{
		source.PlayOneShot(removeline);
	}
	public void PlayLineHurtFromBullet()
	{
		source.PlayOneShot(linehurtfrombullet);
	}
	public void PlayMatrixHurt()
	{
		source.PlayOneShot(matrixhurt);
	}
	public void PlayMatrixDes()
	{
		GetComponent<AudioSource>().PlayOneShot(matrixDes);
	}
	public void PlayLaser()
	{
		laserSource.Play();
	}
	public void CloseLaser()
	{
		laserSource.Pause();
	}

}
