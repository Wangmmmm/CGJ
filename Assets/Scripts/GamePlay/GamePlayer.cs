using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public enum PlayerType
    {
        player1,
        player2
    }

    public class GamePlayer : IGamePlay
    {
        private Transform transform;
        #region variable
        [SerializeField]
        private int energy;
        public PlayerType playerType;
        [Range(0,20)]
        public float speed;
        [Range(0,60)]
        public float rotSpeed;

        /// <summary>
        /// 能量
        /// </summary>
        public int Energy
        {
            get
            {
                return energy;
            }
            set
            {
                energy = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 是否外边保护基地
        /// </summary>
        /// <returns></returns>
        public bool OnProtect()
        {
            return default(bool);
        }

        /// <summary>
        /// 是否在受到伤害
        /// </summary>
        /// <returns></returns>
        public bool OnHurt()
        {
            return default(bool);
        }

        /// <summary>
        /// 是否在基地恢复能量
        /// </summary>
        /// <returns></returns>
        public bool OnRecover()
        {
            return default(bool);
        }

        /// <summary>
        /// 移动控制
        /// </summary>
        public void PlayerMove()
        {
            float currentX = 0, currentZ = 0, _speed = 0;

            switch (playerType)
            {
                case PlayerType.player1:
                    currentX = Input.GetAxis("Horizontal1");
                    currentZ = Input.GetAxis("Vertical1");
                    break;
                case PlayerType.player2:
                    currentX = Input.GetAxis("Horizontal2");
                    currentZ = Input.GetAxis("Vertical2");
                    break;
            }

            if (currentX != 0 || currentZ != 0)            
                _speed = speed;         
            else
                _speed = 0;

            
            Vector3 pos = transform.position;
            Vector3 rot = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rot.x, ClampAngle(rot.y, 0, 360), rot.z);

            if (currentX > 0)
            {
                if(currentZ> 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 45, 0)), Time.deltaTime * rotSpeed);
                }
                else if(currentZ == 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), Time.deltaTime * rotSpeed);
                }
                else if (currentZ < 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 135, 0)), Time.deltaTime * rotSpeed);
                }
            }
            else if(currentX == 0)
            {
                if (currentZ > 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime * rotSpeed);
                }
                else if (currentZ < 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), Time.deltaTime * rotSpeed);
                }
            }
            else if(currentX < 0)
            {
                if (currentZ > 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 315, 0)), Time.deltaTime * rotSpeed);
                }
                else if (currentZ == 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(new Vector3(0,270,0)), Time.deltaTime * rotSpeed);
                }
                else if (currentZ < 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 225, 0)), Time.deltaTime * rotSpeed);
                }
            }
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360) angle += 360;
            if (angle > 360) angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }

        /// <summary>
        /// 发射射线
        /// </summary>
        public void ShootRay()
        {

        }

        /// <summary>
        /// 接收射线
        /// </summary>
        public void ReceiveRay()
        {

        }

        /// <summary>
        /// 射线断裂
        /// </summary>
        public void BreakRay()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        void IGamePlay.Init()
        {
            
        }

        /// <summary>
        /// 更新
        /// </summary>
        void IGamePlay.Update()
        {
            PlayerMove();
        }
        #endregion
    }
}