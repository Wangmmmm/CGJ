using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
public class MatrixCollider : MonoBehaviour {

	private TheMatrix matrix;

	public void BindObject(TheMatrix matrix)
	{
		this.matrix=matrix;
	}

	void OnTriggerEnter(Collider other)
	{
		
	}
}
