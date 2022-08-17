using Controller.Pool;
using UnityEngine;

namespace Controller.Spawn.ObstacleSpawn
{
    public class ObstaclesGroup : MonoBehaviour, IPoolBehaviour
    {
        [SerializeField] private Transform endPoint;

        public Transform EndPoint => endPoint;

        public void OnInitialize() { }
        public void OnSetup() { }
        public void OnReset() { }
    }
}