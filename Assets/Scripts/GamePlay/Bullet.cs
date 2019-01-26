using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{


public enum BulletType
{
	Normal,
	Ray
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
	public float damage;
	public float energyConsume;
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

	private float length;
	
	public float Length
	{
		get{
			return length;
		}
		set{
			length=value;
			collider.SetLength(length);
		}
	}
	public RayBullet(GameObject GO)
	{
		BulletObject=GO;
	}
	RayBulletBehavior behavior;
	public RayBulletCollider collider;
	public override void Init()
	{
		damage=300;
		energyConsume=50;
		collider =BulletObject.GetComponentInChildren<RayBulletCollider>();
		collider.BindObject(this);
		behavior = BulletObject.GetComponentInChildren<RayBulletBehavior>();
		behavior.BindObject(this);
		behavior.Init();
	
		ResetLength();
		
	}

	public void ResetLength()
	{
		collider.endPos=GameManager.gamePlay.GetIGamePlay<TheMatrix>()[0].matrixGO.transform.position;
		Length=behavior.distance;
		
	}
	public void HitObstacle(Obstacle obstacle)
	{
		Length=(obstacle.transform.position-collider.transform.position).magnitude;
	}

	public void HitLine(RayLine line,Vector3 pos)
	{
		Length=(pos-collider.transform.position).magnitude;
		line.GetDamageFromBullet(this,true);
	}
	public void HitMatrix(TheMatrix matrix)
	{
		matrix.Hitted(this,true);
	}

	float initTime=0;
	
	bool spawned=false;
	bool prevue=false;
	public override void Update()
	{
		
		initTime+=Time.deltaTime;
		if(initTime>behavior.spawnTime&&!prevue)
		{
			prevue=true;
			behavior.Prevue();
		}

		if(initTime>=behavior.preLastTime+behavior.spawnTime&&!spawned)
		{
			behavior.Spawn();
			spawned=true;
		}
		if(initTime>=behavior.lifeTime+behavior.preLastTime+behavior.spawnTime)
		{
			this.Destroy();
		}
		behavior.OnUpdate();
	}
	
	public override void Destroy()
	{
		GameObject.Destroy(this.BulletObject);
		GameManager.gamePlay.RemoveIGamePlayList(this);
	
	}
}

}