using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class BulletCollider : MonoBehaviour
    {
		public Bullet bullet;
		public void BindObj(Bullet bul)
		{
			this.bullet=bul;                                                                                                                                                                                                                                       
		}
        void OnCollisionEnter(Collision other)
        {
         
            RayLineData rayLineData = other.gameObject.GetComponent<RayLineData>();
            if (rayLineData != null)
            {
				rayLineData.rayLine.GetDamageFromBullet(bullet.damage);
                return;
            }
            GamePlayerData gamePlayerData = other.gameObject.GetComponent<GamePlayerData>();
            if(gamePlayerData!=null)
            {
                gamePlayerData.gamePlayer.rayLine.GetDamageFromBullet(bullet.damage);
                return;
            }
            Debug.Log(other.gameObject.name);
            MatrixCollider matrixCollider = other.gameObject.GetComponentInChildren<MatrixCollider>();
            if(matrixCollider!=null)
            {
                matrixCollider.matrix.Hitted(this.bullet);
            }
        }
    }
}