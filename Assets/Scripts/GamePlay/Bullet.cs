using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{


public enum BulletType
{
	Normal,

}

public class BulletQuene
{
	
}



public class Bullet:IGamePlay  {
	public int damage;
	private GameObject BulletObject;
	
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

	}
	public override void Update()
	{

	}
}

}