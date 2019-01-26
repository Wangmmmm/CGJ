using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay
{
    public class GamePlayManager : MonoBehaviour
    {

        // Use this for initialization

        public GamePlayBuild gamePlayBuild;
        public PlayerManager playerManager;
        BulletManager bulletManager;
        public RayLine rayLine;

        List<IGamePlay> gamePlayList = new List<IGamePlay>();

        public void AddIGamePlayList(IGamePlay igamePlay)
        {
            if (gamePlayList.Contains(igamePlay))
            {
                Debug.Log("Already exist in IGamePlayList");
                return;
            }
            gamePlayList.Add(igamePlay);
        }

        public void RemoveIGamePlayList(IGamePlay igamePlay)
        {
            if (!gamePlayList.Contains(igamePlay))
            {
                Debug.Log("Already remove from IGamePlayList");
                return;
            }
            gamePlayList.Remove(igamePlay);
        }

        void Awake()
        {
            gamePlayBuild = new GamePlayBuild();
            bulletManager = new BulletManager();
            playerManager = new PlayerManager();
            gamePlayBuild.Init();
        }

        // Update is called once per frame
        void Update()
        {
            foreach(var igamePlay in gamePlayList)
            {
                igamePlay.Update();
            }
        }
    }
}
