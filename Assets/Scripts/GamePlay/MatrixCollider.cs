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
        if (other.GetComponent<GamePlayerData>() != null)
        {
            other.GetComponent<GamePlayerData>().gamePlayer.inMatrix = true;
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GamePlayerData>() != null)
        {
            other.GetComponent<GamePlayerData>().gamePlayer.inMatrix = false;
        }
    }
}
