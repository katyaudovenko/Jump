using Controller.Pool.ByKey;
using Model.Services.ServiceLocator;
using UnityEngine;

namespace Controller.Spawn.ObstacleSpawn
{
    public class GameFactory : IService
    {
        private const string PoolContainerPath = "Prefabs/KeyPoolContainer";

        private KeyPoolContainer _poolContainer;

        public void Initialize()
        {
            var prefab = Resources.Load<KeyPoolContainer>(PoolContainerPath);
            _poolContainer = Object.Instantiate(prefab);
            _poolContainer.CreatePools();
        }
        
        
        public T CreateObstacle<T>(string key,Transform transform, Vector3 position) where T : ObstaclesGroup
        {
            var prefab = _poolContainer.GetFreeElement<T>(key);
            prefab.transform.position = position;
            prefab.transform.SetParent(transform);
            prefab.SetupPool(key, _poolContainer);
            return prefab;
        }
    }
}