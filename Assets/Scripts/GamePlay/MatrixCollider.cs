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

       // if()


	}

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GamePlayerData>() != null)
        {
            other.GetComponent<GamePlayerData>().gamePlayer.inMatrix = false;
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        
    }
    /// <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        
    }
}
