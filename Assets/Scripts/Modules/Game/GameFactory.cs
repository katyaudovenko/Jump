using Infrastructure.Pool.ByType;
using Infrastructure.Services;
using Modules.PlayerComponents;
using UnityEngine;

namespace Modules.Game
{
    public class GameFactory : IService
    {
        private const string PoolContainerPath = "Prefabs/GameEntitiesPoolContainer";
        
        private TypePoolContainer _poolContainer;

        public void Initialize()
        {
            var prefab = Resources.Load<TypePoolContainer>(PoolContainerPath);
            _poolContainer = Object.Instantiate(prefab);
            _poolContainer.CreatePools();
        }

        public Transform CreatePlayer(Transform transform, Vector3 position)
        {
            var player = _poolContainer.GetFreeElement<PlayerDestroyComponent>();
            player.transform.position = position;
            player.transform.SetParent(transform, false);
            player.SetupPool(_poolContainer);
            return player.transform;
        }
    }
}