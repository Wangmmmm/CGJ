using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{


public enum BulletType
{
	Normal,

}

public class NormalBulletQueueGamePlay:IGamePlay{


	GameObject obj;
	List<Bullet> bullets=new List<Bullet>();
	public NormalBulletQueueGamePlay(GameObject obj)
	{
		this.obj=obj;
		this.Init();
	}
	public void Init(){
		
	}
	public List<Bullet> GetBullets()
	{
		return bullets;
	}
	float currentTime =0;
	public  void Update()
	{
		if(currentTime>-1)
			currentTime+=Time.deltaTime;
	
		if(currentTime>obj.GetComponent<NormalBulletQueue>().spawnTime)
		{
			obj.GetComponent<NormalBulletQueue>().Spawn();

			foreach(var BulletMovement in obj.transform.GetComponentsInChildren<NormalBulletMovement>())
			{
				Bullet bullet = new NormalBullet();
				bullets.Add(bullet);
				bullet.bulletType=BulletType.Normal;
				bullet.BulletObject = BulletMovement.gameObject;
				bullet.Init();

				GameManager.gamePlay.AddIGamePlayList(bullet);
			}


			currentTime=-1;
		}
	}


}



public class Bullet:IGamePlay  {
	public int damage;
	public GameObject BulletObject;
	
	public BulletType bulletType;
	public virtual void Init(){

	}

	public virtual void Update()
	{

	}

}

public class NormalBullet:Bullet
{
	public override void Init()
	{
		damage=10;
		var collider =BulletObject.GetComponentInChildren<BulletCollider>();
		collider.BindObj(this);
	}
	public override void Update()
	{
		Debug.Log("test");
	}
}

}