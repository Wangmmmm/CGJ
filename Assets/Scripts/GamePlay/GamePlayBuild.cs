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
            MatrixPrefab = LoadObject(MyConst.MatrixPath);
        }
        public void BuildMatrix()
        {

        }


		






        private GameObject LoadObject(string path)
        {
            return Resources.Load(MyConst.PrefabPath + path) as GameObject;
        }
    }
}