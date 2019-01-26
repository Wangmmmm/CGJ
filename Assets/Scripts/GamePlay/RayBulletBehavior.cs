using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{
public class RayBulletBehavior : MonoBehaviour {

	// Use this for initialization
	//publ

	public RayBullet rayBullet;
	public float spawnTime;

	public float preLastTime;
	public float rotateSpeed;
	public float distance;

	public float lifeTime;
	public Transform matrix;
	
	public void BindObject(RayBullet rayBullet)
	{
		this.rayBullet = rayBullet;
		
	}
	public void Init()
	{
		distance=(matrix.position-transform.position).magnitude;

	}
	public void Prevue()
	{
		transform.Find("Prevue").gameObject.SetActive(true);
		LineRenderer line =transform.Find("Prevue").gameObject.GetComponent<LineRenderer>();
		line.SetPosition(0,transform.position);
		line.SetPosition(1,matrix.position);
	}
	private bool spawned=false;
	public void Spawn()
	{
		transform.Find("Spawn").gameObject.SetActive(true);
		transform.Find("Prevue").gameObject.SetActive(false);

		transform.Find("Ray").gameObject.GetComponent<BoxCollider>().enabled=true;
		transform.Find("Ray").gameObject.GetComponent<LineRenderer>().enabled=true;
		spawned=true;
	}
	public void OnUpdate () {

		
		if(spawned)
		{
			transform.RotateAround(matrix.position,Vector3.up,rotateSpeed*Time.deltaTime);
			LineRenderer linerenderer  = transform.Find("Ray").GetComponent<LineRenderer>();
			linerenderer.SetPosition(0,transform.position);
			rayBullet.collider.CheckLineIntersection();
		}
	}
}
}