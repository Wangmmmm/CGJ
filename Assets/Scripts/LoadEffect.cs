using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay
{
    public class LoadEffect
    {
        public void LoadMatrixBoom()
        {
            GameObject go = Resources.Load<GameObject>(MyConst.PrefabPath + "MatrixBoom");
            go = GameObject.Instantiate(go);
            go.transform.position = GameManager.gamePlay.GetIGamePlay<TheMatrix>()[0].matrixGO.transform.position;
            GameObject.Destroy(go, 2f);           
        }

        public void LoadBulletBoom(Vector3 pos)
        {
            GameObject go = Resources.Load<GameObject>(MyConst.PrefabPath + "BulletBoom");
            go = GameObject.Instantiate(go);
            go.transform.position = pos;
            GameObject.Destroy(go, 2f);
        }

    }
}