using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class GamePlayBuild
    {


        public GameObject MatrixPrefab;



        public void Init()
        {
            //MatrixPrefab = LoadObject(MyConst.MatrixPath);
        }
        public void BuildMatrix()
        {
			GameObject matrixObj = GameObject.Find("Matrix");
			TheMatrix matrix = new TheMatrix(matrixObj);

        }

		public void BuildBullet()
		{
			InitBullet();
            GameObject bulletParent=GameObject.Find("Bullets");
            foreach(var movement in bulletParent.transform.GetComponentsInChildren<NormalBulletQueue>())
            {
                movement.Init();
            }



		}

		private void InitBullet()
		{
			
		}

        public void InitPlayer()
        {
            GameObject player1Obj = GameObject.Find("Player1");
            GameObject player2Obj = GameObject.Find("Player2");
            GameManager.gamePlay.playerManager.player1 = new GamePlayer(PlayerType.player1, player1Obj);
            GameManager.gamePlay.playerManager.player2 = new GamePlayer(PlayerType.player2, player2Obj);
        }

        public void InitRayline()
        {
            GameObject rayLineObj = GameObject.Find("RayLine");
            GameManager.gamePlay.rayLine = new RayLine(rayLineObj);
        }


        private GameObject LoadObject(string path)
        {
            return Resources.Load(MyConst.PrefabPath + path) as GameObject;
        }
    }
}