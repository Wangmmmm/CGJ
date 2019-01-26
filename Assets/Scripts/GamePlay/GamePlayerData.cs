using UnityEngine;

namespace GamePlay
{
    public class GamePlayerData : MonoBehaviour
    {
        [Range(0, 20)]
        public float speed;
        [Range(0, 60)]
        public float rotSpeed;
    }
}