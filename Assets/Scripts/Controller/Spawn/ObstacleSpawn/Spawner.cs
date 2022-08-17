using System.Collections.Generic;
using Controller.Pool.ByKey;
using Model.Services.ServiceLocator;
using UnityEngine;

namespace Controller.Spawn.ObstacleSpawn
{
    public class Spawner : MonoBehaviour
    {
        private const string StartObstacleKey = "StartObstacle";
        private const string BaseObstacleKey = "BaseObstacle";
        
        [SerializeField] private KeyPoolInfoConfig keyPoolInfoConfig;

        private GameFactory _gameFactory;
        private readonly Queue<ObstaclesGroup> _obstacles = new Queue<ObstaclesGroup>();

        private void Awake()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            SpawnStartObstacles();
        }

        private void SpawnStartObstacles()
        {
            var startObstacle = SpawnObstacle(StartObstacleKey, Vector3.zero);
            _obstacles.Enqueue(startObstacle);
            var baseObstacle = SpawnObstacle(BaseObstacleKey, startObstacle.EndPoint.position);
            _obstacles.Enqueue(baseObstacle);
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