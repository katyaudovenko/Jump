using Infrastructure.Services;
using Libs.Components;
using Modules.Events;
using Modules.Game;
using UnityEngine;

namespace Modules.Spawn.GameEntitiesSpawn
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private CameraMove cameraMove;
        
        private GameFactory _gameFactory;

        private void Awake()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            SpawnPlayer();
        }

        private void OnEnable() => 
            GlobalEventManager.StartGame += SpawnPlayer;

        private void OnDisable() => 
            GlobalEventManager.StartGame -= SpawnPlayer;

        private void SpawnPlayer()
        {
            var playerTransform = _gameFactory.CreatePlayer(transform, Vector3.zero);
            cameraMove.SetPlayerTransform(playerTransform);
        }
    }
}