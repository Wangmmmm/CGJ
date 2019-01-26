using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class BulletCollider : MonoBehaviour
    {
		private Bullet bullet;
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
            

        }
    }
}