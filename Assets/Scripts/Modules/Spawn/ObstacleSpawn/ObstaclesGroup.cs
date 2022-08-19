using System;
using Infrastructure.Pool;
using Infrastructure.Pool.ByKey;
using Modules.ObstacleComponents;
using UnityEngine;

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

        public void OnInitialize() {}

        public void OnSetup()
        {
            _isGroupPass = false;
            checkPoint.OnCheckPoint += OnCheckPoint;
        }

        public void OnReset()
        {
            checkPoint.OnCheckPoint -= OnCheckPoint;
            OnGroupPass = null;
        }

        public void DestroyObstacle() => 
            _pool.ReturnElement(_obstacleKey, this);

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