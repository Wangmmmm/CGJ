using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
using UnityEngine.UI;
using DG.Tweening;

public class SceneLoader : MonoBehaviour {

    public float timer;
    public GameObject CG;
    public GameObject End;

    public Sprite cg1;
    public Sprite cg2;
    public Sprite win1;
    public Sprite win2;
    public Sprite win3;
    public Sprite win4;
    public Sprite defeat1;
    public Sprite defeat2;
    public Sprite defeat3;
    public Sprite defeat4;

    public bool isCG;
    public GameObject mask;
    public GameObject Canvas;

	// Use this for initialization
	void Start () {
        CG = GameObject.Find("CG");
        End = GameObject.Find("End");
        isCG = true;
        var cg = CG.AddComponent<Image>();
        cg.raycastTarget = false;
        cg.sprite = cg1;
        cg.DOFade(0.99f, 4).onComplete = delegate ()
         {
             cg.sprite = cg2;
             cg.color =new Color(1, 1, 1, 1);
             cg.DOFade(0, 4).onComplete = delegate ()
             {
                 isCG = false;
                 Init();
             };
         };

    }
	
    void Init()
    {
        GamePlayBuild build = GameManager.gamePlay.gamePlayBuild;


        GameManager.gamePlay.gamePlayBuild.BuildMatrix();
        GameManager.gamePlay.gamePlayBuild.BuildBullet();

        GameManager.gamePlay.gamePlayBuild.InitPlayer();
        GameManager.gamePlay.gamePlayBuild.InitRayline();

        GameManager.gamePlay.AddIGamePlayList(GameManager.gamePlay.playerManager.player1);
        GameManager.gamePlay.AddIGamePlayList(GameManager.gamePlay.playerManager.player2);
        GameManager.gamePlay.AddIGamePlayList(GameManager.gamePlay.rayLine);
    }

    public void Victory()
    {
        isCG = true;
        var cg = End.AddComponent<Image>();
        cg.raycastTarget = false;
        cg.sprite = win1;
        cg.DOFade(0.5f, 2).onComplete = delegate ()
        {
            cg.sprite = win2;
            cg.color = new Color(1, 1, 1, 1);
            cg.DOFade(0.5f, 4).onComplete = delegate ()
            {
                cg.sprite = win3;
                cg.color = new Color(1, 1, 1, 1);
                cg.DOFade(0.5f, 2).onComplete = delegate ()
                {
                    cg.sprite = win4;
                    cg.color = new Color(1, 1, 1, 1);
                    cg.DOFade(0, 4).onComplete = delegate ()
                    {
                        isCG = false;
                         Canvas.transform.Find("GameWin").gameObject.SetActive(true);
                    };
                };
            };
        };
    }

    public void Defeat()
    {
        isCG = true;
        var cg = End.AddComponent<Image>();
        cg.raycastTarget = false;
        cg.sprite = defeat1;
        cg.DOFade(0.5f, 2).onComplete = delegate ()
        {
            cg.sprite = defeat2;
            cg.color = new Color(1, 1, 1, 1);
            cg.DOFade(0.5f, 2).onComplete = delegate ()
            {
                cg.sprite = defeat3;
                cg.color = new Color(1, 1, 1, 1);
                cg.DOFade(0.5f, 4).onComplete = delegate ()
                {
                    cg.sprite = defeat4;
                    cg.color = new Color(1, 1, 1, 1);
                    cg.DOFade(0, 4).onComplete = delegate ()
                    {
                        isCG = false;
                       Canvas.transform.Find("GameOver").gameObject.SetActive(true);
                    };
                };
            };
        };
    }

	// Update is called once per frame
	void Update () {
        if (isCG)
        {
            mask.SetActive(true);
             return;
        }
        else
        {
              mask.SetActive(false);
        }
        if(Canvas.transform.Find("GameOver").gameObject.activeInHierarchy)
         return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Victory();
        }
	}

    public void ReStart()
    {
        GameManager.gamePlay.ClearGamePlay();
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
