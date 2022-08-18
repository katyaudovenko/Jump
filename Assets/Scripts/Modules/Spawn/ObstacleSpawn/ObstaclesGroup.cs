using System;
using Infrastructure.Pool;
using Infrastructure.Pool.ByKey;
using UnityEngine;
using View.ObstacleComponents;

namespace Modules.Spawn.ObstacleSpawn
{
    public class ObstaclesGroup : MonoBehaviour, IPoolBehaviour
    {
        public event Action OnGroupPass;

        [SerializeField] private Transform endPoint;
        [SerializeField] private CheckPoint checkPoint;
        
        private KeyPoolContainer _pool;
        private string _obstacleKey;
        private bool _isGroupPass;

        public Transform EndPoint => endPoint;
        public void SetupPool(string obstacleKey, KeyPoolContainer pool)
        {
            _obstacleKey = obstacleKey;
            _pool = pool;
        }

        public void OnInitialize()
        {
            checkPoint.OnCheckPoint += OnCheckPoint;
        }

        public void OnSetup()
        {
            _isGroupPass = false;
        }

        public void OnReset() { }

        public void DestroyObstacle()
        {
            _pool.ReturnElement(_obstacleKey, this);
        }

        private void OnCheckPoint()
        {
            if (!_isGroupPass)
            {
                OnGroupPass?.Invoke();
                _isGroupPass = true;
            }
        }
    }
}