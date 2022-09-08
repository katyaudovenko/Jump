using Libs.Components;
using Modules.PlayerComponents;
using UnityEngine;

namespace Modules.ObstacleComponents
{
    public class Spike : MonoBehaviour
    {
        private CollisionComponent _collisionComponent;

        private Collision2D _playerCollision;
        private PlayerDestroyComponent _playerDestroyComponent;
        
        private void Awake() => 
            _collisionComponent = GetComponent<CollisionComponent>();

        private void OnEnable() => 
            _collisionComponent.OnCollisionEnter += OnCollision;

        private void OnDisable() => 
            _collisionComponent.OnCollisionEnter -= OnCollision;

        private void OnCollision(Collision2D collision)
        {
            if (_playerCollision != collision)
            {
                _playerDestroyComponent = collision.gameObject.GetComponent<PlayerDestroyComponent>();
                _playerCollision = collision;
            }
            
            _playerDestroyComponent.DestroyPlayer();
        }
    }
}