using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletMovement : MonoBehaviour {
	private Vector3 beginPos;
	private Vector3 beginDir;

	private Vector3 moveDir;

	private float speed;

	public void Init(Vector3 beginPos,Vector3 beginDir,Vector3 moveDir,float speed)
	{
		this.beginPos=beginPos;
		this.beginDir=beginDir;
		this.moveDir=moveDir;
		this.speed=speed;


		transform.position=beginPos;
		transform.eulerAngles=beginDir;
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		
	}
}
