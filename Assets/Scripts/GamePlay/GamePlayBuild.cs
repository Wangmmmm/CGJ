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


		}

		public void InitBullet()
		{

		}




        private GameObject LoadObject(string path)
        {
            return Resources.Load(MyConst.PrefabPath + path) as GameObject;
        }
    }
}