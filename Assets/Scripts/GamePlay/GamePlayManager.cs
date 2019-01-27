using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay
{
    public class GamePlayManager : MonoBehaviour
    {

        // Use this for initialization
        public LoadEffect loadEffect;
        public GamePlayBuild gamePlayBuild;
        public PlayerManager playerManager;
        BulletManager bulletManager;
        public RayLine rayLine;

        List<IGamePlay> gamePlayList = new List<IGamePlay>();
        List<IGamePlay> gamePlayAddBuffer = new List<IGamePlay>();
         List<IGamePlay> gamePlayDeleteBuffer = new List<IGamePlay>();
        public void AddIGamePlayList(IGamePlay igamePlay)
        {
            if (gamePlayList.Contains(igamePlay))
            {
                Debug.Log("Already exist in IGamePlayList");
                return;
            }
            gamePlayAddBuffer.Add(igamePlay);
        }

        public void RemoveIGamePlayList(IGamePlay igamePlay)
        {
            if (!gamePlayList.Contains(igamePlay))
            {
                Debug.Log("Already remove from IGamePlayList");
                return;
            }
            gamePlayDeleteBuffer.Add(igamePlay);
        }
        public List<T> GetIGamePlay<T>()where T:class,IGamePlay
        {
            List<T> list =new List<T>();
            foreach(IGamePlay gameplay in gamePlayList)
            {
                T gameplayObj= gameplay as T;
                if(gameplayObj!=null)
                list.Add(gameplayObj);

            }
            foreach(IGamePlay gameplay in gamePlayAddBuffer)
            {
                 T gameplayObj= gameplay as T;
                if(gameplayObj!=null)
                list.Add(gameplayObj);
            }
            return list;
        }
        public void ClearGamePlay()
        {
            gamePlayList.Clear();
        }
        void Awake()
        {
            gamePlayBuild = new GamePlayBuild();
            bulletManager = new BulletManager();
            playerManager = new PlayerManager();
            loadEffect = new LoadEffect();
            gamePlayBuild.Init();
        }

        // Update is called once per frame
        void Update()
        {
            foreach(var buffer in gamePlayAddBuffer)
            {
                gamePlayList.Add(buffer);
            }
            gamePlayAddBuffer.Clear();

            foreach(var buffer in gamePlayDeleteBuffer)
            {
                gamePlayList.Remove(buffer);
            }
            gamePlayDeleteBuffer.Clear();

            foreach(var igamePlay in gamePlayList)
            {
                igamePlay.Update();
            }
        }
    }
}
