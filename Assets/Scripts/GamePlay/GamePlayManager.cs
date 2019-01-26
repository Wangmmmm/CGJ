using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{
public class GamePlayManager : MonoBehaviour {

	// Use this for initialization
	
	GamePlayBuild gamePlayBuild;

	BulletManager bulletManager;

	void Start () {
		gamePlayBuild = new GamePlayBuild();
		bulletManager = new BulletManager();
		gamePlayBuild.Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
