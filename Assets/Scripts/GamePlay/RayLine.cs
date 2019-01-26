using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class RayLine:IGamePlay  {

        public RayLine(GameObject obj)
        {
            transform = obj.transform;
            if (obj.GetComponent<RayLineData>() != null)
            {
                data = obj.GetComponent<RayLineData>();
            }
            else
            {
                data = obj.AddComponent<RayLineData>();
            }
            currentEnergy = data.MaxEnergy;
            data.rayLine = this;
            if (obj.GetComponent<RayLineCollider>() != null)
            {
                collider = obj.GetComponent<RayLineCollider>();
            }
            else
            {
                collider = obj.AddComponent<RayLineCollider>();
            }
            collider.rayLine = this;
        }

        public float currentEnergy;
        public RayLineData data;
        public RayLineCollider collider;
        public Transform transform;
        private bool isLeaving;
        private GamePlayer player1 = GameManager.gamePlay.playerManager.player1;
        private GamePlayer player2 = GameManager.gamePlay.playerManager.player2;
        public float Length
        {
            get
            {
                return Vector3.Distance(player1.transform.position, player2.transform.position);
            }
        }
        public Vector3 Pos
        {
            get
            {
                return (player1.transform.position + player2.transform.position) / 2;
            }
        }
        public Vector3 Det
        {
            get
            {
                return player1.transform.position - player2.transform.position;

            }
        }

        public void RecoverEnergy()
        {
            if (currentEnergy < data.MaxEnergy)
            {
                currentEnergy += data.RecoverEnergySpeed * Time.deltaTime;
            }
            else
                currentEnergy = data.MaxEnergy;
        }

        public bool GetDamageFromBullet(float damage)
        {
            currentEnergy -= damage;
            return currentEnergy > 0;
        }

        public bool GetDamageFromLength()
        {
            currentEnergy -= Length * data.DecFromLengthSpeed * Time.deltaTime;
            return currentEnergy > 0;
        }

        public bool IsMaxEnergy()
        {
            return currentEnergy >= data.MaxEnergy;
        }

        private float ClampEnergy(float energy, float min, float max)
        {
            if (energy < min)
                return min;
            else if (energy > max)
                return max;
            else
                return energy;
        }


        private void SetEnergy()
        {
            if(player1.inMatrix && player2.inMatrix)
            {
                isLeaving = true;
                RecoverEnergy();
            }
            else if(!player1.inMatrix && !player2.inMatrix)
            {
                isLeaving = false;
                GetDamageFromLength();
            }
            else if(!isLeaving)
            {
                currentEnergy = 0;
            }
        }

        private void SetLineRenderer()
        {
            var lineRenderer = transform.GetComponent<LineRenderer>();
            if (currentEnergy > 0 && !player1.inMatrix && !player2.inMatrix)
            {
                lineRenderer.enabled = true;
                Vector3[] points = new Vector3[2]
               {
                player1.transform.position,
                player2.transform.position
               };
                lineRenderer.SetPositions(points);

            }
            else
            {
                lineRenderer.enabled = false;
            }
        }

        private void SetCollider()
        {
            var collider = transform.GetComponent<BoxCollider>();
            if (currentEnergy > 0 && !player1.inMatrix && !player2.inMatrix)
            {
                collider.enabled = true;
                collider.size = new Vector3(Length, 1, 1);
            }
            else
            {
                collider.enabled = false;
            }
        }

        void IGamePlay.Init()
        {
            
        }

        void IGamePlay.Update()
        {
            SetEnergy();
            SetLineRenderer();
            SetCollider();
            currentEnergy = ClampEnergy(currentEnergy, 0, data.MaxEnergy);         
            transform.position = Pos;
            transform.right = Det;           
        }

        
        public void Destroy()
        {
            
        }
    }
}