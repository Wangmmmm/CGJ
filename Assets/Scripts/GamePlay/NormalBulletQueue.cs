using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletQueue : MonoBehaviour {

	public float spawnTime;
	public int bulletCount;
	public Vector3 moveDir;

	public float interval;
	

	[SerializeField, SetProperty("DirTarget")]
	private Transform dirTarget;
	public Transform DirTarget
	{
		set
		{
			Vector3 targetPos= value.position;
			moveDir = targetPos-transform.position;
			moveDir=moveDir.normalized;
			Debug.Log("修改朝向成功");
		}
	}


	public float moveSpeed;

	private List<NormalBulletMovement> bulletList = new List<NormalBulletMovement>();

	public void Init()
	{
		GameObject bulletTemplate=transform.Find("Bullet").gameObject;
		bulletTemplate.SetActive(false);
	}
	public void Spawn()
	{

		InitBullet();
	}
	public void InitBullet()
	{
		GameObject bulletTemplate=transform.Find("Bullet").gameObject;
		for(int i=0;i<bulletCount;i++)
		{
			GameObject bullet = Instantiate(bulletTemplate,this.transform);
			Transform bulletTrans = bullet.transform;
			NormalBulletMovement movement =bullet.GetComponent<NormalBulletMovement>();
			bullet.SetActive(true);
			Vector3 pos = i*interval*(-moveDir);
			Vector3 dir= moveDir;
			float speed = moveSpeed;
			movement.Init(pos,dir,dir,speed);
			//bulletTrans.localPosition = transform.localPosition + i*interval*(-moveDir);
			bulletList.Add(movement);			
		}
	}
	float currentTime =0;
	void Update()
	{
		if(currentTime>-1)
			currentTime+=Time.deltaTime;
	
		if(currentTime>spawnTime)
		{
			Spawn();
			currentTime=-1;
		}
	}
}
