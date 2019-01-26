using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay{
public class GamePlayManager : MonoBehaviour {

	// Use this for initialization
	
	GamePlayBuild gamePlayBuild;




	

	void Start () {
		gamePlayBuild = new GamePlayBuild();
		gamePlayBuild.Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
