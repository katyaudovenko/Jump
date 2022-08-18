using System.Collections.Generic;
using Infrastructure.Pool.ByKey;
using Infrastructure.Services.ServiceLocator;
using UnityEngine;

namespace Modules.Spawn.ObstacleSpawn
{
    public class Spawner : MonoBehaviour
    {
        private const string StartObstacleKey = "StartObstacle";
        private const string BaseObstacleKey = "BaseObstacle";
        private const int MinObstaclesCountOnScene = 3;

        [SerializeField] private KeyPoolInfoConfig keyPoolInfoConfig;

        private GameFactory _gameFactory;
        private ObstaclesGroup _lastSpawnedObstacle;
        private readonly Queue<ObstaclesGroup> _obstacles = new Queue<ObstaclesGroup>();

        private void Awake()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            
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
            _gameFactory.CreateObstacle<ObstaclesGroup>(key, transform, position);
    }
}