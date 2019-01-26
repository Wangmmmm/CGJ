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
            if (other.gameObject.name == "Player1")
                GameManager.gamePlay.playerManager.player1.inMatrix = true;
            else
                GameManager.gamePlay.playerManager.player2.inMatrix = true;
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GamePlayerData>() != null)
        {
            if (other.gameObject.name == "Player1")
                GameManager.gamePlay.playerManager.player1.inMatrix = false;
            else
                GameManager.gamePlay.playerManager.player2.inMatrix = false;
        }
    }
}
