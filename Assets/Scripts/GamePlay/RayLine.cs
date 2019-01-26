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
        }

        public float currentEnergy;
        public RayLineData data;
        public Transform transform;
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

        public void OnRecover()
        {
            if (player1.inMatrix && player2.inMatrix)
            {
                if (currentEnergy < data.MaxEnergy)
                {
                    currentEnergy += data.RecoverEnergySpeed * Time.deltaTime;
                }
                else
                    currentEnergy = data.MaxEnergy;
            }
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

        private void SetLineRenderer()
        {
            var lineRenderer = transform.GetComponent<LineRenderer>();
            Vector3[] points = new Vector3[2]
           {
                player1.transform.position,
                player2.transform.position
           };
            lineRenderer.SetPositions(points);
        }

        private void SetCollider()
        {
            var collider = transform.GetComponent<Collider>();
            //collider.s
        }

        void IGamePlay.Init()
        {
            
        }

        void IGamePlay.Update()
        {
            SetLineRenderer();
            currentEnergy = ClampEnergy(currentEnergy, 0, data.MaxEnergy);         
            transform.position = Pos;
            if(GetDamageFromLength())
            {

            }
            else
            {

            }
        }
    }
}