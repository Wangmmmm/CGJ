using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{
public class TheMatrix : IGamePlay {

	private GameObject matrixGO;


	private int health;



	public TheMatrix(GameObject obj)
	{
		matrixGO = obj;
		this.Init();
	}
	// Use this for initialization
	public void Init () {
		matrixGO.GetComponent<MatrixCollider>().BindObject(this); 
		health = MyConst.MatrixMaxHealth;
	}


	public void Hitted()
	{

	}

	public void Destoyed()
	{

	}
	
	//public void HandleEvent(EventData eventData)
	// Update is called once per frame
	public void Update () {
		
	}

}
}