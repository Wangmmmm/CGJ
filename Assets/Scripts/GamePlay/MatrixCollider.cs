using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
public class MatrixCollider : MonoBehaviour {

	public TheMatrix matrix;

	public void BindObject(TheMatrix matrix)
	{
		this.matrix=matrix;
	}
 
	void OnTriggerEnter(Collider other)
	{

         // Debug.Log("trige");
        if (other.GetComponent<GamePlayerData>() != null)
        {
            other.GetComponent<GamePlayerData>().gamePlayer.inMatrix = true;
        }

       // if()


	}

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GamePlayerData>() != null)
        {
            other.GetComponent<GamePlayerData>().gamePlayer.inMatrix = false;
        }
    }




}
