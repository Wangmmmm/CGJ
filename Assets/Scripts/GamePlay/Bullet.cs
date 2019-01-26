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
	//List<Bullet> bullets=new List<Bullet>();
	public NormalBulletQueueGamePlay(GameObject obj)
	{
		this.obj=obj;
		this.Init();
	}
	public void Init(){
		
	}
	private int childCount=0;
	// public List<Bullet> GetBullets()
	// {
	// 	return bullets;
	// }
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
				NormalBullet bullet = new NormalBullet();
				//bullets.Add(bullet);
				bullet.bulletType=BulletType.Normal;
				bullet.BulletObject = BulletMovement.gameObject;
				bullet.normalBulletQueueGamePlay=this;
				bullet.Init();
				childCount++;
				GameManager.gamePlay.AddIGamePlayList(bullet);
			}


			currentTime=-1;
		} 
	}
	public void Destroy()
	{
			GameObject.Destroy(this.obj);
			GameManager.gamePlay.RemoveIGamePlayList(this);
	}
	public void OnBulletDestroy()
	{
		childCount--;
		if(childCount==0)
		{
			this.Destroy();
		}
	}

}



public class Bullet:IGamePlay  {
	public int damage;
	public int energyConsume;
	public GameObject BulletObject;
	


	public BulletType bulletType;
	public virtual void Init(){

	}

	public virtual void Update()
	{

	}

	
	public virtual void Destroy()
	{
		
	}

}

public class NormalBullet:Bullet
{

	public NormalBulletQueueGamePlay normalBulletQueueGamePlay ;
	public override void Init()
	{
		damage=120;
		energyConsume=120;
		var collider =BulletObject.GetComponentInChildren<BulletCollider>();
		collider.BindObj(this);
	}
	public override void Update()
	{
	//	Debug.Log("test");
	}
	
	public override void Destroy()
	{
		GameObject.Destroy(this.BulletObject);
		GameManager.gamePlay.RemoveIGamePlayList(this);
		normalBulletQueueGamePlay.OnBulletDestroy();
	}
}

public class RayBullet:Bullet
{

	


	public override void Init()
	{
		damage=300;
		energyConsume=80;
		var collider =BulletObject.GetComponentInChildren<BulletCollider>();
		collider.BindObj(this);
	}
	public override void Update()
	{
	//	Debug.Log("test");
	}
	
	public override void Destroy()
	{
		GameObject.Destroy(this.BulletObject);
		GameManager.gamePlay.RemoveIGamePlayList(this);
	
	}
}

}