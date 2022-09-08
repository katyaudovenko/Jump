using System.Collections.Generic;
using Infrastructure.Pool.ByKey;
using Infrastructure.Services;
using UnityEngine;

namespace Modules.Spawn.ObstacleSpawn
{
    public class ObstaclesSpawner : MonoBehaviour
    {
        private const string StartObstacleKey = "StartObstacle";
        private const string BaseObstacleKey = "BaseObstacle";
        private const int MinObstaclesCountOnScene = 3;

        [SerializeField] private KeyPoolInfoConfig keyPoolInfoConfig;

        private readonly Queue<ObstaclesGroup> _obstacles = new Queue<ObstaclesGroup>();
        
        private ObstaclesFactory _obstaclesFactory;
        private ObstaclesGroup _lastSpawnedObstacle;

        private void Awake()
        {
            _obstaclesFactory = ServiceLocator.Instance.GetService<ObstaclesFactory>();
            
            SpawnStartObstacle();
            SpawnNextObstacle(_lastSpawnedObstacle.EndPoint);
        }

        private void SpawnStartObstacle()
        {
            var startObstacle = SpawnObstacle(StartObstacleKey, Vector3.zero);
            startObstacle.OnGroupPass += OnGroupPass;
            _obstacles.Enqueue(startObstacle);
            _lastSpawnedObstacle = startObstacle;
        }

        private void SpawnNextObstacle(Transform endPoint)
        {
            var nextObstacle = SpawnObstacle(BaseObstacleKey, endPoint.position);
            nextObstacle.OnGroupPass += OnGroupPass;
            _obstacles.Enqueue(nextObstacle);
            _lastSpawnedObstacle = nextObstacle;
        }

        private void OnGroupPass()
        {
            SpawnNextObstacle(_lastSpawnedObstacle.EndPoint);
            DestroyLastObstacle();
        }

        private void DestroyLastObstacle()
        {
            if (_obstacles.Count > MinObstaclesCountOnScene)
            {
                var lastObstacle = _obstacles.Dequeue();
                lastObstacle.DestroyObstacle();
            }
        }
        
        private ObstaclesGroup SpawnObstacle(string substringKey, Vector3 position)
        {
            var baseObstacles = keyPoolInfoConfig.keyPoolsInfo.
                FindAll(k => k.key.Contains(substringKey));
            var obstacleIndex = Random.Range(0, baseObstacles.Count);
            var obstacleKey = baseObstacles[obstacleIndex].key;
            var obstacle = GenerateObstacle(obstacleKey, position);
            
            return obstacle;
        }

        private ObstaclesGroup GenerateObstacle(string key, Vector3 position) => 
            _obstaclesFactory.CreateObstacle<ObstaclesGroup>(key, transform, position);
    }
}