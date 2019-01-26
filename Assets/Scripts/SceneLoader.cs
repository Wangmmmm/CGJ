using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
public class SceneLoader : MonoBehaviour {

    public float timer;

	// Use this for initialization
	void Start () {

		GamePlayBuild build = GameManager.gamePlay.gamePlayBuild;


        GameManager.
        gamePlay.
        gamePlayBuild.
        BuildMatrix();
        GameManager.gamePlay.gamePlayBuild.BuildBullet();
        
        



        GameManager.gamePlay.gamePlayBuild.InitPlayer();
        GameManager.gamePlay.gamePlayBuild.InitRayline();

        GameManager.gamePlay.AddIGamePlayList(GameManager.gamePlay.playerManager.player1);
        GameManager.gamePlay.AddIGamePlayList(GameManager.gamePlay.playerManager.player2);
        GameManager.gamePlay.AddIGamePlayList(GameManager.gamePlay.rayLine);


    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
	}
}
