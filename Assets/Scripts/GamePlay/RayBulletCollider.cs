using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay
{
    public class RayBulletCollider : MonoBehaviour
    {

        public RayBullet bullet;
		private Obstacle hitObstacle;

		private RayLine hitLine;
        public void BindObject(RayBullet bullet)
        {
            this.bullet = bullet;
        }
		
        public void SetLength(float length)
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.size = new Vector3(length, 1, 1);
            boxCollider.center = new Vector3(length / 2 + 0.5f, 0, 0);



			if(hitLine!=null)
			{
				
			}
			else if(hitObstacle!=null)
			{

			}
			else{

			}
        }


		public void CheckLineIntersection()
		{
			RayLine rayLine =GameManager.gamePlay.rayLine;
			//if(rayLine.currentEnergy==0)return;
			if(!rayLine.IsActive())
			{
				
				if(hitLine!=null)
				{
					bullet.ResetLength();
					hitLine=null;
				}
			}
			Vector3 targetPos;

			if(hitObstacle)
			{
				targetPos=hitObstacle.transform.position;
			}
			else{
				targetPos=GameManager.gamePlay.GetIGamePlay<TheMatrix>()[0].matrixGO.transform.position;
			}
			Vector3 player1Pos=GameManager.gamePlay.playerManager.player1.transform.position;
			Vector3 player2Pos=GameManager.gamePlay.playerManager.player2.transform.position;

			Vector3 selfPos=transform.position;
		//	Vector3 matrixPos = GameManager.gamePlay.GetIGamePlay<TheMatrix>()[0].matrixGO.transform.position;
			Vector3 interserctionPos;
			int result =  GetIntersection(player1Pos, player2Pos,selfPos,targetPos,out interserctionPos);

			if(result==1)
			{
				bullet.HitLine(rayLine,interserctionPos);
				hitLine=rayLine;
				if(hitObstacle)
				{
					hitObstacle=null;
				}
			}
			if(result==0)
			{
				if(hitLine!=null)
				{
					bullet.ResetLength();
					hitLine=null;
				}
			}
		}
        /// <summary>
        /// OnCollisionEnter is called when this collider/rigidbody has begun
        /// touching another rigidbody/collider.
        /// </summary>
        /// <param name="other">The Collision data associated with this collision.</param>
        void OnCollisionEnter(Collision other)
        {
			
            MatrixCollider matrix = other.collider.gameObject.GetComponentInChildren<MatrixCollider>();
            if (matrix != null)
            {
                bullet.HitMatrix(matrix.matrix);
				
                return;
            }

        }
        /// <summary>
        /// OnCollisionStay is called once per frame for every collider/rigidbody
        /// that is touching rigidbody/collider.
        /// </summary>
        /// <param name="other">The Collision data associated with this collision.</param>
        void OnCollisionStay(Collision other)
        {
             MatrixCollider matrix = other.collider.gameObject.GetComponentInChildren<MatrixCollider>();
            if (matrix != null)
            {
                bullet.HitMatrix(matrix.matrix);
                return;
            }
            GamePlay.Obstacle obstacle = other.collider.gameObject.GetComponentInChildren<Obstacle>();
            if (obstacle != null)
            {
                bullet.HitObstacle(obstacle);
				hitObstacle=obstacle;
            }
        }



        /// <summary>
        /// OnCollisionExit is called when this collider/rigidbody has
        /// stopped touching another rigidbody/collider.
        /// </summary>
        /// <param name="other">The Collision data associated with this collision.</param>
        void OnCollisionExit(Collision other)
        {
            GamePlay.Obstacle obstacle = other.collider.gameObject.GetComponentInChildren<Obstacle>();
            if (obstacle != null)
            {
				bullet.ResetLength();
				hitObstacle=null;
            }
        }



        public static int GetIntersection(Vector3 a, Vector3 b, Vector3 c, Vector3 d, out Vector3 contractPoint)
        {
            contractPoint = new Vector3(0, 0);

            if (Mathf.Abs(b.z - a.z) + Mathf.Abs(b.x - a.x) + Mathf.Abs(d.z - c.z)
                    + Mathf.Abs(d.x - c.x) == 0)
            {
                if ((c.x - a.x) + (c.z - a.z) == 0)
                {
                    //Debug.Log("ABCD是同一个点！");
                }
                else
                {
                    //Debug.Log("AB是一个点，CD是一个点，且AC不同！");
                }
                return 0;
            }

            if (Mathf.Abs(b.z - a.z) + Mathf.Abs(b.x - a.x) == 0)
            {
                if ((a.x - d.x) * (c.z - d.z) - (a.z - d.z) * (c.x - d.x) == 0)
                {
                    //Debug.Log("A、B是一个点，且在CD线段上！");
                }
                else
                {
                    //Debug.Log("A、B是一个点，且不在CD线段上！");
                }
                return 0;
            }
            if (Mathf.Abs(d.z - c.z) + Mathf.Abs(d.x - c.x) == 0)
            {
                if ((d.x - b.x) * (a.z - b.z) - (d.z - b.z) * (a.x - b.x) == 0)
                {
                    //Debug.Log("C、D是一个点，且在AB线段上！");
                }
                else
                {
                    //Debug.Log("C、D是一个点，且不在AB线段上！");
                }
                return 0;
            }

            if ((b.z - a.z) * (c.x - d.x) - (b.x - a.x) * (c.z - d.z) == 0)
            {
                //Debug.Log("线段平行，无交点！");
                return 0;
            }

            contractPoint.x = ((b.x - a.x) * (c.x - d.x) * (c.z - a.z) -
                    c.x * (b.x - a.x) * (c.z - d.z) + a.x * (b.z - a.z) * (c.x - d.x)) /
                    ((b.z - a.z) * (c.x - d.x) - (b.x - a.x) * (c.z - d.z));
            contractPoint.z = ((b.z - a.z) * (c.z - d.z) * (c.x - a.x) - c.z
                    * (b.z - a.z) * (c.x - d.x) + a.z * (b.x - a.x) * (c.z - d.z))
                    / ((b.x - a.x) * (c.z - d.z) - (b.z - a.z) * (c.x - d.x));

            if ((contractPoint.x - a.x) * (contractPoint.x - b.x) <= 0
                    && (contractPoint.x - c.x) * (contractPoint.x - d.x) <= 0
                    && (contractPoint.z - a.z) * (contractPoint.z - b.z) <= 0
                    && (contractPoint.z - c.z) * (contractPoint.z - d.z) <= 0)
            {

                //Debug.Log("线段相交于点(" + contractPoint.x + "," + contractPoint.z + ")！");
                return 1; // '相交  
            }
            else
            {
                //Debug.Log("线段相交于虚交点(" + contractPoint.x + "," + contractPoint.z + ")！");
                return -1; // '相交但不在线段上  
            }
        }
    }
}