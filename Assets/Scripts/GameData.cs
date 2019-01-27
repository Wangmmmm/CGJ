using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
public class GameData : MonoBehaviour {

    public float rayCurrentEnergy;
    public float rayMaxEnergy;
    public float timer;
    public float matrixCurrentLife;
    public float matrixMaxLife;

    void GetMatrixData()
    {
        matrixMaxLife = MyConst.MatrixMaxHealth;
        int count = GameManager.gamePlay.GetIGamePlay<TheMatrix>().Count;
        if(count==0)
            matrixCurrentLife=matrixMaxLife;
        else{
               var matrix = GameManager.gamePlay.GetIGamePlay<TheMatrix>()[0];
                matrixCurrentLife = matrix.health;
        }
     
        
    }

    void GetRayLineData()
    {
        var rayLine = GameManager.gamePlay.rayLine;
        if (rayLine == null)
        {
            rayCurrentEnergy = 10;
            rayMaxEnergy = 10;
        }
        else
        {
            rayCurrentEnergy = rayLine.currentEnergy;
            rayMaxEnergy = rayLine.data.MaxEnergy;
        }
    }

    void GetLevelData()
    {
        timer = GameObject.Find("SceneLoader").GetComponent<SceneLoader>().timer;
    }

    private void Update()
    {
        GetMatrixData();
        GetRayLineData();
        GetLevelData();
    }
}
