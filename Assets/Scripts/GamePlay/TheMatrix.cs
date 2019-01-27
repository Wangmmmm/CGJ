using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GamePlay{
public class TheMatrix : IGamePlay {

	public GameObject matrixGO;



	public float health;


	bool wudi;

	public TheMatrix(GameObject obj)
	{
		matrixGO = obj;
		this.Init();
	}
	// Use this for initialization
	Toggle toggle;
	public void Init () {
		
		
		foreach(var collider in matrixGO.transform.GetComponentsInChildren<MatrixCollider>())
		{
			collider.BindObject(this);
		}




		health = MyConst.MatrixMaxHealth;


		toggle=GameObject.Find("Toggle").GetComponent<Toggle>();
	}


	public void Hitted(Bullet bullet,bool perframe=false)
	{
		float damage = 0;
	
		if(!perframe)
		{
			damage=bullet.damage;
			GameManager.gamePlay.loadEffect.LoadBulletBoom(bullet.BulletObject.transform.position);
			AudioManager.instance.PlayMatrixHurt();
		}
		else{
			damage=bullet.damage*Time.fixedDeltaTime;
		}
		if(!toggle.isOn)
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
			foreach(var collider in matrixGO.transform.GetComponentsInChildren<Collider>())
			{
				collider.enabled=false;
			}
			Camera.main.GetComponent<Shake>().OnShake();
			GameManager.gamePlay.loadEffect.LoadMatrixBoom();
			matrixGO.transform.Find("home").GetComponent<MeshRenderer>().enabled=false;
			matrixGO.transform.Find("MatrixRecover").gameObject.SetActive(false);
			AudioManager.instance.PlayMatrixDes();
                GameObject.Find("SceneLoader").GetComponent<SceneLoader>().Defeat();
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