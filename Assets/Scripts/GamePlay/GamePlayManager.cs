﻿using System.Collections;
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

        }
    }
}
