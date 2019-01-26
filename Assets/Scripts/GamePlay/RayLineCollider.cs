using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class RayLineCollider : MonoBehaviour {

        public RayLine rayLine;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<LineBreakObject>() != null)
            {
                rayLine.currentEnergy = 0;
            }
        }

    }
}