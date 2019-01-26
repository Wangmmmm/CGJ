using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{
public class TheMatrix : IGamePlay {

	public GameObject matrixGO;



	public float health;




	public TheMatrix(GameObject obj)
	{
		matrixGO = obj;
		this.Init();
	}
	// Use this for initialization
	public void Init () {
		
		
		foreach(var collider in matrixGO.transform.GetComponentsInChildren<MatrixCollider>())
		{
			collider.BindObject(this);
		}


		health = MyConst.MatrixMaxHealth;
	}


	public void Hitted(Bullet bullet,bool perframe=false)
	{
		float damage = 0;
		if(!perframe)
			damage=bullet.damage;
		else{
			damage=bullet.damage*Time.fixedDeltaTime;
		}
		health-=damage;
		EventData  hitEvenData = new EventData();
		hitEvenData.eventType = EventEnum.MatrixHit;
		hitEvenData.param=(object)bullet.damage;
		GameManager.eventSystem.Raise(hitEvenData);
		//Debug.Log("基地被撞擊");
		if(!perframe)
		bullet.Destroy();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
		if(health<=0)
		{
			
			EventData  desEvenData = new EventData();
			desEvenData.eventType = EventEnum.MatrixHit;
			desEvenData.sender=(object)this;
			GameManager.eventSystem.Raise(desEvenData);
			Debug.Log("基地被毀滅");
		}
	}


	
	//public void HandleEvent(EventData eventData)
	// Update is called once per frame
	public void Update () {
		
	}

	
	public void Destroy()
	{
		
	}

}
}