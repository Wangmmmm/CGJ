using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
[RequireComponent(typeof(GamePlayManager))]
public class GameManager : MonoBehaviour {

	// Use this for initialization
	private static GameManager instance;

	public static GameManager Instance
	{
		get
		{
			if(instance==null)
			{
				Debug.LogError("UnInitedGameManager");
				return null;
			}
			return instance;
		}
	}

	public static GamePlayManager gamePlay;

	public static EventSystem eventSystem;
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
		instance=GetComponent<GameManager>();
		gamePlay=GetComponent<GamePlayManager>();
		eventSystem= new EventSystem();
	}
	

}
